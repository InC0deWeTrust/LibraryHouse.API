using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryHouse.Application.Books;
using LibraryHouse.Application.Dtos.Books;

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
        [Route("Create")]
        public async Task CreateBook(CreateBookDto createBookDto)
        {
            await _bookService.Create(createBookDto);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<BookDto> GetBookById(int bookId)
        {
            return await _bookService.GetById(bookId);
        }
    }
}
