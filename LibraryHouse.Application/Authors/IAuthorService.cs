using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryHouse.Infrastructure.Entities.Authors;

namespace LibraryHouse.Application.Authors
{
    public interface IAuthorService
    {
        Task<bool> Create(Author author);
    }
}
