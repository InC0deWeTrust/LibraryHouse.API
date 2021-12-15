using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryHouse.Application.Books;
using LibraryHouse.Application.Dtos.Books;
using Microsoft.AspNetCore.Authorization;

namespace LibraryHouse.Web.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("Create")]
        public async Task CreateBook([FromBody] CreateBookDto createBookDto)
        {
            await _bookService.Create(createBookDto);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<BookDto> GetBookById([FromHeader] int bookId)
        {
            return await _bookService.GetById(bookId);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<List<BookDto>> GetAllBooks()
        {
            return await _bookService.GetAll();
        }

        [HttpPut]
        [Route("Update")]
        public async Task UpdateBook([FromBody] UpdateBookDto updateBookDto)
        {
            await _bookService.Update(updateBookDto);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task DeleteBook([FromHeader] int bookId)
        {
            await _bookService.Delete(bookId);
        }

        [HttpPost]
        [Route("ReserveBook")]
        public async Task ReserveBookForUser([FromHeader] int userId, int bookId)
        {
            await _bookService.TakeBook(userId, bookId);
        }

        [HttpDelete]
        [Route("ReturnBook")]
        public async Task UserReturnBookBack([FromHeader] int userId, int bookId)
        {
            await _bookService.ReturnBook(userId, bookId);
        }

        [HttpPost]
        [Route("AddCompany")]
        public async Task AssignCompanyToBook([FromHeader] int bookId, int companyId)
        {
            await _bookService.AssignCompanyToBook(bookId, companyId);
        }

        [HttpDelete]
        [Route("RemoveCompany")]
        public async Task RemoveCompanyFromBook([FromHeader] int bookId, int companyId)
        {
            await _bookService.UnsignCompanyForBook(bookId, bookId);
        }
    }
}
