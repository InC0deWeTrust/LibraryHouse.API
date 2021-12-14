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
using LibraryHouse.Infrastructure.Entities.Roles;
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
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<UserRole> _userRoleRepository;
        private readonly IRoleService _roleService;

        public UserService(
            ILogger<UserService> logger,
            IMapper mapper,
            IRepository<User> userRepository,
            IRepository<Role> roleRepository,
            IRepository<UserRole> userRoleRepository,
            IRoleService roleService)
        {
            _logger = logger;
            _mapper = mapper;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
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

            newUser.UserName = newUser.FirstName + newUser.LastName;

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

        public async Task Update(UpdateUserDto updateUserDto)
        {
            var user = await _userRepository.GetAsync(updateUserDto.UserId);

            if (user == null)
            {
                _logger.LogError($"Unable to find user with Id: {updateUserDto.UserId} and update him.");
                throw new CustomUserFriendlyException($"Unable to find user and update him!");
            }

            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;
            user.UserName = updateUserDto.FirstName + updateUserDto.LastName;
            user.Address = updateUserDto.Address;
            user.TelephoneNumber = updateUserDto.TelephoneNumber;
            user.Email = updateUserDto.Email;

            _userRepository.Update(user);
        }

        public async Task Delete(int userId)
        {
            var user = await _userRepository.GetAsync(userId);

            if (user == null)
            {
                _logger.LogError($"Unable to find user with Id: {userId} and delete him.");
                throw new CustomUserFriendlyException($"Unable to find user and delete him!");
            }

            _userRepository.Delete(user);
        }

        public async Task AddRole(int userId, int roleId)
        {
            await CheckExistingUserAndRole(userId, roleId);

            var existingUserRole = await _userRoleRepository
                .GetAll()
                .AnyAsync(x => x.UserId == userId && x.RoleId == roleId);

            if (existingUserRole)
            {
                _logger.LogError($"User with Id: {userId} and role with Id: {roleId} already set.");
                throw new CustomUserFriendlyException($"User already have this role!");
            }

            await _roleService.AddRoleForUser(userId, roleId);
        }

        public async Task RemoveRole(int userId, int roleId)
        {
            await CheckExistingUserAndRole(userId, roleId);

            var existingUserRole = await _userRoleRepository
                .GetAll()
                .AnyAsync(x => x.UserId == userId && x.RoleId == roleId);

            if (!existingUserRole)
            {
                _logger.LogError($"User with Id: {userId} and role with Id: {roleId} are not bound.");
                throw new CustomUserFriendlyException($"Unable to remove such role from user!");
            }

            await _roleService.RemoveRoleFromUser(userId, roleId);
        }

        private async Task CheckExistingUserAndRole(int userId, int roleId)
        {
            var existingUser = await _userRepository.GetAsync(userId);

            var existingRole = await _roleRepository.GetAsync(roleId);

            if (existingUser == null || existingRole == null)
            {
                _logger.LogError($"User with Id: {userId} OR role with Id: {roleId} don't exist.");
                throw new CustomUserFriendlyException($"Specified user or role don't exist!");
            }
        }

        public async Task UpdatePassword(UpdateUserPasswordDto updateUserPasswordDto)
        {
            var user = await _userRepository
                .GetAll()
                .FirstOrDefaultAsync(x => x.Email == updateUserPasswordDto.Email);

            if (user == null)
            {
                _logger.LogError($"Unable to find user with email: {updateUserPasswordDto.Email} and change his password.");
                throw new CustomUserFriendlyException($"Incorrect password or email. Try again with different ones!");
            }

            var verifiedPassword = BCrypt.Net.BCrypt.Verify(updateUserPasswordDto.OldPassword, user.Password);

            if (!verifiedPassword)
            {
                _logger.LogError($"Unable to change old password with a new one.");
                throw new CustomUserFriendlyException($"Incorrect password or email. Try again with different ones!");
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(updateUserPasswordDto.NewPassword);

            _userRepository.Update(user);
        }

        public async Task UpdatePasswordData(UpdateUserPassportDataDto updateUserPassportDataDto)
        {
            var user = await _userRepository.GetAsync(updateUserPassportDataDto.UserId);

            if (user == null)
            {
                _logger.LogError($"Unable to find user with Id: {updateUserPassportDataDto.UserId} and update his passport data.");
                throw new CustomUserFriendlyException($"Unable to update passport data!");
            }

            var verifiedPassword = BCrypt.Net.BCrypt.Verify(updateUserPassportDataDto.Password, user.Password);

            if (!verifiedPassword)
            {
                _logger.LogError($"Unable to update passport data due to incorrect password.");
                throw new CustomUserFriendlyException($"Unable to update passport data!");
            }

            user.PassportData = updateUserPassportDataDto.PassportData;

            _userRepository.Update(user);
        }

        public async Task UpdateBankAccount(UpdateUserBankAccountDto updateUserBankAccountDto)
        {
            var user = await _userRepository.GetAsync(updateUserBankAccountDto.UserId);

            if (user == null)
            {
                _logger.LogError($"Unable to find user with Id: {updateUserBankAccountDto.UserId} and update his bank account.");
                throw new CustomUserFriendlyException($"Unable to update bank account!");
            }

            var verifiedPassword = BCrypt.Net.BCrypt.Verify(updateUserBankAccountDto.Password, user.Password);

            if (!verifiedPassword)
            {
                _logger.LogError($"Unable to update bank account due to incorrect password.");
                throw new CustomUserFriendlyException($"Unable to update bank account!");
            }

            user.BankAccount = updateUserBankAccountDto.BankAccount;

            _userRepository.Update(user);
        }
    }
}
