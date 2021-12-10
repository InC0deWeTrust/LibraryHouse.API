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
    }
}
