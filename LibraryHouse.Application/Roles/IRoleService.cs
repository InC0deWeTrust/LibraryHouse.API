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
    }
}
