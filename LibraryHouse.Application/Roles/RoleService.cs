using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryHouse.Application.Dtos.Roles;
using LibraryHouse.Application.Helpers;
using LibraryHouse.Application.Models.Roles;
using LibraryHouse.Infrastructure.Entities.Roles;
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

        public RoleService(
            ILogger<RoleService> logger,
            IMapper mapper,
            IRepository<Role> roleRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task Create(CreateRoleDto createRoleDto)
        {
            var newRoleModel = _mapper.Map<RoleModel>(createRoleDto);

            var existingRole = await _roleRepository
                .GetAll()
                .AnyAsync(x => x.Name == newRoleModel.Name);

            if (existingRole)
            {
                _logger.LogInformation($"Role: {newRoleModel.Name} already exist.");
                throw new CustomUserFriendlyException("This role already exist!");
            }

            var newRole = _mapper.Map<Role>(newRoleModel);

            await _roleRepository.AddAsync(newRole);
        }
    }
}
