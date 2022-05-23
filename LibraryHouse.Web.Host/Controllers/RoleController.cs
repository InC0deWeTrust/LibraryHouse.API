using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryHouse.Application.Dtos.Roles;
using LibraryHouse.Application.Roles;
using Microsoft.AspNetCore.Authorization;

namespace LibraryHouse.Web.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        //[Authorize(Roles = "SuperAdmin, Admin")]
        [Route("Create")]
        public async Task CreateRole([FromBody] CreateRoleDto createRoleDto)
        {
            await _roleService.Create(createRoleDto);
        }

        [HttpGet]
        //[Authorize(Roles = "SuperAdmin, Admin")]
        [Route("Get")]
        public async Task<RoleDto> GetRoleById([FromHeader] int roleId)
        {
            return await _roleService.GetById(roleId);
        }

        [HttpGet]
        //[Authorize(Roles = "SuperAdmin, Admin")]
        [Route("GetAll")]
        public async Task<List<RoleDto>> GetAllRoles()
        {
            return await _roleService.GetAll();
        }

        [HttpPut]
        //[Authorize(Roles = "SuperAdmin, Admin")]
        [Route("Update")]
        public async Task UpdateRole([FromBody] RoleDto roleDto)
        {
            await _roleService.Update(roleDto);
        }

        [HttpDelete]
        //[Authorize(Roles = "SuperAdmin, Admin")]
        [Route("Delete")]
        public async Task DeleteRole(int roleId)
        {
            await _roleService.Delete(roleId);
        }
    }
}
