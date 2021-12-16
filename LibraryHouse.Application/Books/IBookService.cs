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

        Task<FullInfoBookDto> GetByIdFullInfoAboutBook(int bookId);

        Task<List<BookDto>> GetAll();

        Task Update(UpdateBookDto updateBookDto);

        Task Delete(int bookId);

        Task TakeBook(int userId, int bookId);

        Task ReturnBook(int userId, int bookId);

        Task AssignCompanyToBook(int bookId, int companyId);

        Task UnsignCompanyForBook(int bookId, int companyId);

        Task<List<BookTypeDto>> GetAllTypesForBook();
    }
}
