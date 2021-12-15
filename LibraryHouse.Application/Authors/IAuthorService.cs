using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryHouse.Application.Dtos.Authors;
using LibraryHouse.Infrastructure.Entities.Authors;

namespace LibraryHouse.Application.Authors
{
    public interface IAuthorService
    {
        Task<bool> Create(Author author);

        Task<AuthorDto> GetById(int authorId);

        Task<List<AuthorDto>> GetAll();
    }
}
