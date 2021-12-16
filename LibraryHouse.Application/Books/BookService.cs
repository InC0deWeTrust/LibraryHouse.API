using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryHouse.Application.Authors;
using LibraryHouse.Application.Companies;
using LibraryHouse.Application.Dtos.Books;
using LibraryHouse.Application.Helpers;
using LibraryHouse.Application.Users;
using LibraryHouse.Infrastructure.Entities.Authors;
using LibraryHouse.Infrastructure.Entities.Books;
using LibraryHouse.Infrastructure.Entities.Companies;
using LibraryHouse.Infrastructure.Entities.Users;
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
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Company> _companyRepository;
        private readonly IAuthorService _authorService;
        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;

        public BookService(
            ILogger<BookService> logger,
            IMapper mapper,
            IRepository<Book> bookRepository,
            IRepository<BookType> bookTypeRepository,
            IRepository<Author> authorRepository,
            IRepository<User> userRepository,
            IRepository<Company> companyRepository,
            IAuthorService authorService,
            IUserService userService,
            ICompanyService companyService)
        {
            _logger = logger;
            _mapper = mapper;
            _bookRepository = bookRepository;
            _bookTypeRepository = bookTypeRepository;
            _authorRepository = authorRepository;
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _authorService = authorService;
            _userService = userService;
            _companyService = companyService;
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
                throw new CustomUserFriendlyException($"Unable to find book with Id: {bookId}!");
            }

            return _mapper.Map<BookDto>(book);
        }

        public async Task<FullInfoBookDto> GetByIdFullInfoAboutBook(int bookId)
        {
            var book = await _bookRepository
                .GetAll()
                .Include(x => x.Author)
                .Include(x => x.Type)
                .FirstOrDefaultAsync(x => x.Id == bookId);

            if (book == null)
            {
                _logger.LogError($"Unable to find book with Id: {bookId}.");
                throw new CustomUserFriendlyException($"Unable to find book with Id: {bookId}!");
            }

            return _mapper.Map<FullInfoBookDto>(book);
        }

        public async Task<List<BookDto>> GetAll()
        {
            var books = await _bookRepository
                .GetAll()
                .ToListAsync();

            return _mapper.Map<List<BookDto>>(books);
        }

        public async Task Update(UpdateBookDto updateBookDto)
        {
            var book = await _bookRepository.GetAsync(updateBookDto.BookId);

            if (book == null)
            {
                _logger.LogError($"Unable to find book with Id: {updateBookDto.BookId} and update it.");
                throw new CustomUserFriendlyException($"Unable to find book and update it!");
            }

            var newBookType = await SetBookType(updateBookDto.BookType);

            book.BookTypeId = newBookType.Id;

            _bookRepository.Update(book);
        }

        public async Task Delete(int bookId)
        {
            var book = await _bookRepository.GetAsync(bookId);

            if (book == null)
            {
                _logger.LogError($"Unable to find book with Id: {bookId} and delete it.");
                throw new CustomUserFriendlyException($"Unable to find book and delete it!");
            }

            _bookRepository.Delete(book);
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

        public async Task TakeBook(int userId, int bookId)
        {
            await CheckExistingUserAndBook(userId, bookId);

            await _userService.ReserveBookForUser(userId, bookId);
        }

        public async Task ReturnBook(int userId, int bookId)
        {
            await CheckExistingUserAndBook(userId, bookId);

            await _userService.UnreserveBookForUser(userId, bookId);
        }

        private async Task CheckExistingUserAndBook(int userId, int bookId)
        {
            var existingUser = await _userRepository.GetAsync(userId);

            var existingBook = await _bookRepository.GetAsync(bookId);

            if (existingUser == null || existingBook == null)
            {
                _logger.LogError($"User with Id: {userId} OR book with Id: {bookId} don't exist.");
                throw new CustomUserFriendlyException($"Specified user or book don't exist!");
            }
        }

        public async Task AssignCompanyToBook(int bookId, int companyId)
        {
            await CheckExistingBookAndCompany(bookId, companyId);

            await _companyService.AddCompanyForBook(bookId, companyId);
        }

        public async Task UnsignCompanyForBook(int bookId, int companyId)
        {
            await CheckExistingBookAndCompany(bookId, companyId);

            await _companyService.RemoveCompanyFromBook(bookId, companyId);
        }

        private async Task CheckExistingBookAndCompany(int bookId, int companyId)
        {
            var existingBook = await _bookRepository.GetAsync(bookId);

            var existingCompany = await _companyRepository.GetAsync(companyId);

            if (existingBook == null || existingCompany == null)
            {
                _logger.LogError($"Book with Id: {bookId} OR Company with Id: {companyId} don't exist.");
                throw new CustomUserFriendlyException($"Specified Book or Company don't exist!");
            }
        }

        public async Task<List<BookTypeDto>> GetAllTypesForBook()
        {
            var bookTypes = await _bookTypeRepository
                .GetAll()
                .ToListAsync();

            return _mapper.Map<List<BookTypeDto>>(bookTypes);
        }
    }
}
