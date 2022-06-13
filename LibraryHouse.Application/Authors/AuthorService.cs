using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryHouse.Application.Dtos.Authors;
using LibraryHouse.Application.Helpers;
using LibraryHouse.Infrastructure.Entities.Authors;
using LibraryHouse.Infrastructure.Entities.Books;
using LibraryHouse.Infrastructure.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LibraryHouse.Application.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly ILogger<AuthorService> _logger;
        private readonly IMapper _mapper;
        private readonly IRepository<Author> _authorRepository;
        private readonly IRepository<Book> _bookRepository;

        public AuthorService(
            ILogger<AuthorService> logger,
            IMapper mapper,
            IRepository<Author> authorRepository,
            IRepository<Book> bookRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        public async Task<bool> Create(Author author)
        {
            var existingAuthor = await _authorRepository
                .GetAll()
                .FirstOrDefaultAsync(x => x.FirstName == author.FirstName && x.LastName == author.LastName);

            if (existingAuthor != null)
            {
                return false;
            }

            await _authorRepository.AddAsync(author);

            return true;
        }

        public async Task<AuthorDto> GetById(int authorId)
        {
            var author = await _authorRepository.GetAsync(authorId);

            if (author == null)
            {
                _logger.LogError($"Unable to find author with Id: {authorId}.");
                throw new CustomUserFriendlyException($"Unable to find author with Id: {authorId}!");
            }

            var authorDto = _mapper.Map<AuthorDto>(author);

            var bookNames = await _bookRepository.GetAll()
                .Where(x => x.AuthorId == authorDto.AuthorId)
                .Select(x => x.Name)
                .ToListAsync();

            authorDto.BookNames = bookNames;

            return authorDto;
        }

        public async Task<List<AuthorDto>> GetAll()
        {
            var authors = await _authorRepository
                .GetAll()
                .ToListAsync();

            return _mapper.Map<List<AuthorDto>>(authors);
        }
    }
}
