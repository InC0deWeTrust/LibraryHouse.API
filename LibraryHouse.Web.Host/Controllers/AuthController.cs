using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryHouse.Application.Auth;
using LibraryHouse.Application.Dtos.Auth;
using LibraryHouse.Application.Dtos.Login;

namespace LibraryHouse.Web.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<AuthDto> LoginUser([FromBody] LoginDto loginDto)
        {
            return await _authService.Login(loginDto);
        }
    }
}
