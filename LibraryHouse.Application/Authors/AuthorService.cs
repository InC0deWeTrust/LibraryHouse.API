using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryHouse.Infrastructure.Entities.Authors;
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

        public AuthorService(
            ILogger<AuthorService> logger,
            IMapper mapper,
            IRepository<Author> authorRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _authorRepository = authorRepository;
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
    }
}
