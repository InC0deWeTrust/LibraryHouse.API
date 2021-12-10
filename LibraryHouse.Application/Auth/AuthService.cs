using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LibraryHouse.Application.Dtos.Auth;
using LibraryHouse.Application.Dtos.Login;
using LibraryHouse.Application.Dtos.Users;
using LibraryHouse.Application.Helpers;
using LibraryHouse.Application.Roles;
using LibraryHouse.Application.Users;
using LibraryHouse.Infrastructure.Entities.Users;
using LibraryHouse.Infrastructure.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LibraryHouse.Application.Auth
{
    public class AuthService : IAuthService
    {
        private readonly ILogger<AuthService> _logger;
        private readonly IOptions<AuthToken> _options;
        private readonly IRepository<User> _userRepository;
        private readonly IRoleService _roleService;

        public AuthService(
            ILogger<AuthService> logger,
            IOptions<AuthToken> options,
            IRepository<User> userRepository,
            IRoleService roleService)
        {
            _logger = logger;
            _options = options;
            _userRepository = userRepository;
            _roleService = roleService;
        }

        public async Task<AuthDto> Login(LoginDto loginDto)
        {
            var user = await AuthenticateUser(loginDto.Email, loginDto.Password);

            if (user == null)
            {
                _logger.LogError($"User with email: {loginDto.Email} can not be authorized.");
                throw new UnauthorizedAccessException("User is not authorized!");
            }

            var token = await GenerateJWTToken(user);

            var authDto = new AuthDto
            {
                Token = token
            };

            return authDto;
        }

        private async Task<User> AuthenticateUser(string email, string password)
        {
            var user = await _userRepository
                .GetAll()
                .FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                _logger.LogError($"Can't find user with email: {email}.");
                throw new CustomUserFriendlyException("Password or Email is incorrect! Try again with a different ones.");
            }

            var verified = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (!verified)
            {
                _logger.LogError("Passwords are not the same.");
                throw new CustomUserFriendlyException("Password or Email is incorrect! Try again with a different ones.");
            }

            return user;
        }

        private async Task<string> GenerateJWTToken(User user)
        {
            var authParams = _options.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.AtHash, user.Password)
            };

            var userRoles = await _roleService.GetAllRolesForUser(user.Id);

            foreach (var role in userRoles)
            {
                claims.Add(new Claim("role", role.Name));
            }

            var token = new JwtSecurityToken(authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
