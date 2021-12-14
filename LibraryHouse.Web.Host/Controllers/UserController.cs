using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryHouse.Application.Dtos.Users;
using LibraryHouse.Application.Users;

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
        [Route("Get")]
        public async Task<UserDto> GetUserById([FromHeader] int userId)
        {
            return await _userService.GetById(userId);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<List<UserDto>> GetAllUsers()
        {
            return await _userService.GetAll();
        }

        [HttpPut]
        [Route("Update")]
        public async Task UpdateUser([FromBody] UpdateUserDto updateUserDto)
        {
            await _userService.Update(updateUserDto);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task DeleteUser([FromHeader] int userId)
        {
            await _userService.Delete(userId);
        }

        [HttpPost]
        [Route("AssignRoleForUser")]
        public async Task AddRoleForUser([FromHeader] int userId, int roleId)
        {
            await _userService.AddRole(userId, roleId);
        }

        [HttpDelete]
        [Route("UnsignRoleForUser")]
        public async Task RemoveRoleFromUser([FromHeader] int userId, int roleId)
        {
            await _userService.RemoveRole(userId, roleId);
        }

        [HttpPut]
        [Route("UpdatePassword")]
        public async Task UpdateUserPassword([FromBody] UpdateUserPasswordDto updateUserPasswordDto)
        {
            await _userService.UpdatePassword(updateUserPasswordDto);
        }

        [HttpPut]
        [Route("UpdatePassportData")]
        public async Task UpdateUserPassportData([FromBody] UpdateUserPassportDataDto updateUserPassportDataDto)
        {
            await _userService.UpdatePasswordData(updateUserPassportDataDto);
        }

        [HttpPut]
        [Route("UpdateBankAccount")]
        public async Task UpdateUserBankAccount([FromBody] UpdateUserBankAccountDto updateUserBankAccountDto)
        {
            await _userService.UpdateBankAccount(updateUserBankAccountDto);
        }
    }
}
