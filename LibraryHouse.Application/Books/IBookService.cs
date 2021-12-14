using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryHouse.Application.Dtos.Books;

namespace LibraryHouse.Application.Books
{
    public interface IBookService
    {
        Task Create(CreateBookDto createBookDto);

        Task<BookDto> GetById(int bookId);
    }
}
