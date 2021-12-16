using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryHouse.Application.Dtos.Roles;
using LibraryHouse.Application.Helpers;
using LibraryHouse.Infrastructure.Entities.Roles;
using LibraryHouse.Infrastructure.Entities.Users;
using LibraryHouse.Infrastructure.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LibraryHouse.Application.Roles
{
    public class RoleService : IRoleService
    {
        private readonly ILogger<RoleService> _logger;
        private readonly IMapper _mapper;
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<UserRole> _userRoleRepository;

        public RoleService(
            ILogger<RoleService> logger,
            IMapper mapper,
            IRepository<Role> roleRepository,
            IRepository<UserRole> userRoleRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
        }

        public async Task Create(CreateRoleDto createRoleDto)
        {
            var existingRole = await _roleRepository
                .GetAll()
                .AnyAsync(x => x.Name == createRoleDto.Name);

            if (existingRole)
            {
                _logger.LogError($"Role: {createRoleDto.Name} already exist.");
                throw new CustomUserFriendlyException("This role already exist!");
            }

            var newRole = _mapper.Map<Role>(createRoleDto);

            await _roleRepository.AddAsync(newRole);
        }

        public async Task<RoleDto> GetById(int roleId)
        {
            var role = await _roleRepository.GetAsync(roleId);

            if (role == null)
            {
                _logger.LogError($"Unable to find role with Id: {roleId}.");
                throw new CustomUserFriendlyException($"Unable to find role with Id: {roleId}!");
            }

            return _mapper.Map<RoleDto>(role);
        }

        public async Task<List<RoleDto>> GetAll()
        {
            var roles = await _roleRepository
                .GetAll()
                .ToListAsync();

            return _mapper.Map<List<RoleDto>>(roles);
        }

        public async Task Update(RoleDto roleDto)
        {
            var currentRole = await _roleRepository.GetAsync(roleDto.RoleId);

            if (currentRole == null)
            {
                _logger.LogError($"Unable to find role with Id: {roleDto.RoleId} and update it to {roleDto.Name}.");
                throw new CustomUserFriendlyException($"Unable to find and update role with Id: {roleDto.RoleId}!");
            }

            currentRole.Name = roleDto.Name;

            _roleRepository.Update(currentRole);
        }

        public async Task Delete(int roleId)
        {
            var existingRole = await _roleRepository
                .GetAll()
                .FirstOrDefaultAsync(x => x.Id == roleId);

            if (existingRole == null)
            {
                _logger.LogError($"Role with Id: {roleId} don't exist.");
                throw new CustomUserFriendlyException($"Unable to find and delete role with Id: {roleId}!");
            }

            _roleRepository.Delete(existingRole);
        }

        public async Task SetUserRole(int usedId)
        {
            var newBasicRole = new UserRole
            {
                UserId = usedId,
                RoleId = (int) RoleEnum.User
            };

            await _userRoleRepository.AddAsync(newBasicRole);
        }

        public async Task AddRoleForUser(int userId, int roleId)
        {
            var existingUserRole = await _userRoleRepository
                .GetAll()
                .AnyAsync(x => x.UserId == userId && x.RoleId == roleId);

            if (existingUserRole)
            {
                _logger.LogError($"Unable to add role with Id: {roleId} to user with Id: {userId} because relation already exist.");
                throw new CustomUserFriendlyException("User with this role already exist!");
            }

            var newUserRole = new UserRole
            {
                UserId = userId,
                RoleId = roleId
            };

            await _userRoleRepository.AddAsync(newUserRole);
        }

        public async Task RemoveRoleFromUser(int userId, int roleId)
        {
            var existingUserRole = await _userRoleRepository
                .GetAll()
                .FirstOrDefaultAsync(x => x.UserId == userId && x.RoleId == roleId);

            if (existingUserRole == null)
            {
                _logger.LogError($"Unable to remove role with Id: {roleId} from user with Id: {userId} because they are not related.");
                throw new CustomUserFriendlyException("User with this role don't exist!");
            }

            _userRoleRepository.Delete(existingUserRole);
        }

        public async Task<List<RoleDto>> GetAllRolesForUser(int usedId)
        {
            var listOfRolesForSpecificUser = await _userRoleRepository
                .GetAll()
                .Include(x => x.Role)
                .Where(x => x.UserId == usedId)
                .Select(x => x.Role)
                .ToListAsync();

            return _mapper.Map<List<RoleDto>>(listOfRolesForSpecificUser);
        }
    }
}
