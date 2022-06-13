using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryHouse.Application.Dtos.Books;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        Task AddAttachmentForBook(int bookId, IFormFile attachment);

        Task<FileContentResult> DownloadAttachment(int bookId);

        Task AddPicture(int bookId, IFormFile picture);
    }
}
