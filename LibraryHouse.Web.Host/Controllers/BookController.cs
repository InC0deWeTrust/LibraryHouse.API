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
        //[Authorize(Roles = "Admin, SuperAdmin")]
        [Route("Create")]
        public async Task CreateBook([FromBody] CreateBookDto createBookDto)
        {
            await _bookService.Create(createBookDto);
        }

        [HttpGet]
        //[Authorize]
        [Route("Get")]
        public async Task<BookDto> GetBookById([FromHeader] int bookId)
        {
            return await _bookService.GetById(bookId);
        }

        [HttpGet]
        //[Authorize]
        [Route("GetFullInfo")]
        public async Task<FullInfoBookDto> GetFullInfoForBookById([FromHeader] int bookId)
        {
            return await _bookService.GetByIdFullInfoAboutBook(bookId);
        }

        [HttpGet]
        //[Authorize]
        [Route("GetAll")]
        public async Task<List<BookDto>> GetAllBooks()
        {
            return await _bookService.GetAll();
        }

        [HttpGet]
        //[Authorize]
        [Route("GetAllTypes")]
        public async Task<List<BookTypeDto>> GetAllBookTypes()
        {
            return await _bookService.GetAllTypesForBook();
        }

        [HttpPut]
        //[Authorize(Roles = "Admin, SuperAdmin")]
        [Route("Update")]
        public async Task UpdateBook([FromBody] UpdateBookDto updateBookDto)
        {
            await _bookService.Update(updateBookDto);
        }

        [HttpDelete]
        //[Authorize(Roles = "Admin, SuperAdmin")]
        [Route("Delete")]
        public async Task DeleteBook([FromHeader] int bookId)
        {
            await _bookService.Delete(bookId);
        }

        [HttpPost]
        //[Authorize]
        [Route("ReserveBook")]
        public async Task ReserveBookForUser([FromHeader] int userId, int bookId)
        {
            await _bookService.TakeBook(userId, bookId);
        }

        [HttpDelete]
        //[Authorize]
        [Route("ReturnBook")]
        public async Task ReturnBookBackFromUser([FromHeader] int userId, int bookId)
        {
            await _bookService.ReturnBook(userId, bookId);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin, SuperAdmin")]
        [Route("AddCompany")]
        public async Task AssignCompanyToBook([FromHeader] int bookId, int companyId)
        {
            await _bookService.AssignCompanyToBook(bookId, companyId);
        }

        [HttpDelete]
        //[Authorize(Roles = "Admin, SuperAdmin")]
        [Route("RemoveCompany")]
        public async Task RemoveCompanyFromBook([FromHeader] int bookId, int companyId)
        {
            await _bookService.UnsignCompanyForBook(bookId, bookId);
        }
    }
}
