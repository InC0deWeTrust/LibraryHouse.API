using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryHouse.Application.Authors;
using LibraryHouse.Application.Dtos.Authors;
using Microsoft.AspNetCore.Authorization;

namespace LibraryHouse.Web.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<AuthorDto> GeyAuthorById(int authorId)
        {
            return await _authorService.GetById(authorId);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<List<AuthorDto>> GeyAllAuthors()
        {
            return await _authorService.GetAll();
        }
    }
}
