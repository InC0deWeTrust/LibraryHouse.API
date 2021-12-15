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

        Task Update(UpdateUserDto updateUserDto);

        Task Delete(int userId);

        Task AddRole(int userId, int roleId);

        Task RemoveRole(int userId, int roleId);

        Task UpdatePassword(UpdateUserPasswordDto updateUserPasswordDto);

        Task UpdatePasswordData(UpdateUserPassportDataDto updateUserPassportDataDto);

        Task UpdateBankAccount(UpdateUserBankAccountDto updateUserBankAccountDto);

        Task ReserveBookForUser(int userId, int bookId);

        Task UnreserveBookForUser(int userId, int bookId);
    }
}
