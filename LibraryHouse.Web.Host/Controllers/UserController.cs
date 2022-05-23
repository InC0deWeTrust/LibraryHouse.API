using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryHouse.Application.Dtos.Users;
using LibraryHouse.Application.Users;
using Microsoft.AspNetCore.Authorization;

namespace LibraryHouse.Web.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task CreateUser(CreateUserDto createUserDto)
        {
            await _userService.Create(createUserDto);
        }

        [HttpGet]
        //[Authorize(Roles = "SuperAdmin, Admin")]
        [Route("Get")]
        public async Task<UserDto> GetUserById([FromHeader] int userId)
        {
            return await _userService.GetById(userId);
        }

        [HttpGet]
        //[Authorize(Roles = "SuperAdmin, Admin")]
        [Route("GetAll")]
        public async Task<List<UserDto>> GetAllUsers()
        {
            return await _userService.GetAll();
        }

        [HttpPut]
        //[Authorize(Roles = "SuperAdmin, Admin")]
        [Route("Update")]
        public async Task UpdateUser([FromBody] UpdateUserDto updateUserDto)
        {
            await _userService.Update(updateUserDto);
        }

        [HttpDelete]
        //[Authorize(Roles = "SuperAdmin, Admin")]
        [Route("Delete")]
        public async Task DeleteUser([FromHeader] int userId)
        {
            await _userService.Delete(userId);
        }

        [HttpPost]
        //[Authorize(Roles = "SuperAdmin, Admin")]
        [Route("AssignRoleForUser")]
        public async Task AddRoleForUser([FromHeader] int userId, int roleId)
        {
            await _userService.AddRole(userId, roleId);
        }

        [HttpDelete]
        //[Authorize(Roles = "SuperAdmin, Admin")]
        [Route("UnsignRoleForUser")]
        public async Task RemoveRoleFromUser([FromHeader] int userId, int roleId)
        {
            await _userService.RemoveRole(userId, roleId);
        }

        [HttpPut]
        //[Authorize(Roles = "User, SuperAdmin, Admin")]
        [Route("UpdatePassword")]
        public async Task UpdateUserPassword([FromBody] UpdateUserPasswordDto updateUserPasswordDto)
        {
            await _userService.UpdatePassword(updateUserPasswordDto);
        }

        [HttpPut]
        //[Authorize(Roles = "User")]
        [Route("UpdatePassportData")]
        public async Task UpdateUserPassportData([FromBody] UpdateUserPassportDataDto updateUserPassportDataDto)
        {
            await _userService.UpdatePasswordData(updateUserPassportDataDto);
        }

        [HttpPut]
        //[Authorize(Roles = "User")]
        [Route("UpdateBankAccount")]
        public async Task UpdateUserBankAccount([FromBody] UpdateUserBankAccountDto updateUserBankAccountDto)
        {
            await _userService.UpdateBankAccount(updateUserBankAccountDto);
        }
    }
}
