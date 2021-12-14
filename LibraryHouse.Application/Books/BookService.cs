using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryHouse.Application.Authors;
using LibraryHouse.Application.Dtos.Books;
using LibraryHouse.Application.Helpers;
using LibraryHouse.Infrastructure.Entities.Authors;
using LibraryHouse.Infrastructure.Entities.Books;
using LibraryHouse.Infrastructure.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LibraryHouse.Application.Books
{
    public class BookService : IBookService
    {
        private readonly ILogger<BookService> _logger;
        private readonly IMapper _mapper;
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<BookType> _bookTypeRepository;
        private readonly IRepository<Author> _authorRepository;
        private readonly IAuthorService _authorService;

        public BookService(
            ILogger<BookService> logger,
            IMapper mapper,
            IRepository<Book> bookRepository,
            IRepository<BookType> bookTypeRepository,
            IRepository<Author> authorRepository,
            IAuthorService authorService)
        {
            _logger = logger;
            _mapper = mapper;
            _bookRepository = bookRepository;
            _bookTypeRepository = bookTypeRepository;
            _authorRepository = authorRepository;
            _authorService = authorService;
        }

        public async Task Create(CreateBookDto createBookDto)
        {
            var bookType = await SetBookType(createBookDto.BookType);

            var author = new Author
            {
                FirstName = createBookDto.AuthorName.ToLower(),
                LastName = createBookDto.AuthorSurname.ToLower()
            };

            var result = await _authorService.Create(author);

            if (!result)
            {
                author = await _authorRepository
                    .GetAll()
                    .FirstOrDefaultAsync(x => x.FirstName == author.FirstName && x.LastName == author.LastName);
            }

            var newBook = new Book
            {
                Name = createBookDto.Name.ToLower(),
                DateOfDelivery = DateTime.Now,
                BookTypeId = bookType.Id,
                AuthorId = author.Id
            };

            await _bookRepository.AddAsync(newBook);
        }

        public async Task<BookDto> GetById(int bookId)
        {
            var book = await _bookRepository.GetAsync(bookId);

            if (book == null)
            {
                _logger.LogError($"Unable to find book with Id: {bookId}.");
                throw new CustomUserFriendlyException("Unable to find book with Id: {bookId}!");
            }

            return _mapper.Map<BookDto>(book);
        }

        private async Task<BookType> SetBookType(string bookType)
        {
            var existingBookType = await _bookTypeRepository
                .GetAll()
                .FirstOrDefaultAsync(x => x.Type.ToLower() == bookType.ToLower());

            if (existingBookType == null)
            {
                _logger.LogError($"Book type with value {bookType} have not been found!");
                throw new CustomUserFriendlyException(
                    $"There is no such type of book as {bookType}. Please, pay attention to spelling!");
            }

            return existingBookType;
        }
    }
}
