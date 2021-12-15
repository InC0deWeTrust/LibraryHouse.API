using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryHouse.Application.Dtos.Roles;

namespace LibraryHouse.Application.Roles
{
    public interface IRoleService
    {
        Task Create(CreateRoleDto createRoleDto);

        Task<RoleDto> GetById(int roleId);

        Task<List<RoleDto>> GetAll();

        Task Update(RoleDto roleDto);

        Task Delete(int roleId);

        Task SetBasicRole(int usedId);

        Task AddRoleForUser(int userId, int roleId);

        Task RemoveRoleFromUser(int userId, int roleId);

        Task<List<RoleDto>> GetAllRolesForUser(int usedId);
    }
}
