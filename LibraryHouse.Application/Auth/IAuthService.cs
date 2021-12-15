using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryHouse.Application.Dtos.Auth;
using LibraryHouse.Application.Dtos.Login;

namespace LibraryHouse.Application.Auth
{
    public interface IAuthService
    {
        Task<AuthDto> Login(LoginDto loginDto);
    }
}
