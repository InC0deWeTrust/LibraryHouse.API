using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryHouse.Application.Dtos.Users;
using LibraryHouse.Application.Helpers;
using LibraryHouse.Application.Roles;
using LibraryHouse.Infrastructure.Entities.Users;
using LibraryHouse.Infrastructure.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LibraryHouse.Application.Users
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;
        private readonly IRepository<User> _userRepository;
        private readonly IRoleService _roleService;

        public UserService(
            ILogger<UserService> logger,
            IMapper mapper,
            IRepository<User> userRepository,
            IRoleService roleService)
        {
            _logger = logger;
            _mapper = mapper;
            _userRepository = userRepository;
            _roleService = roleService;
        }

        public async Task Create(CreateUserDto createUserDto)
        {
            var existingEmail = await _userRepository
                .GetAll()
                .AnyAsync(x => x.Email == createUserDto.Email);

            if (existingEmail)
            {
                _logger.LogError($"User with email: {createUserDto.Email} already exist.");
                throw new CustomUserFriendlyException("This email is already registered. Please try again with another one!");
            }

            var newUser = _mapper.Map<User>(createUserDto);

            newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

            await _userRepository.AddAsync(newUser);

            await _roleService.SetBasicRole(newUser.Id);
        }

        public async Task<UserDto> GetById(int userId)
        {
            var user = await _userRepository.GetAsync(userId);

            if (user == null)
            {
                _logger.LogError($"Unable to find user with Id: {userId}.");
                throw new CustomUserFriendlyException($"Unable to find user with Id: {userId}!");
            }

            return _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> GetAll()
        {
            var users = await _userRepository
                .GetAll()
                .ToListAsync();

            return _mapper.Map<List<UserDto>>(users);
        }
    }
}
