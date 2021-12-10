using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryHouse.Application.Dtos.Users;

namespace LibraryHouse.Application.Users
{
    public interface IUserService
    {
        Task Create(CreateUserDto createUserDto);

        Task<UserDto> GetById(int userId);

        Task<List<UserDto>> GetAll();
    }
}
