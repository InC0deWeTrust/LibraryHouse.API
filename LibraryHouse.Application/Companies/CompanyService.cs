using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryHouse.Application.Dtos.Companies;
using LibraryHouse.Application.Helpers;
using LibraryHouse.Infrastructure.Entities.Books;
using LibraryHouse.Infrastructure.Entities.Companies;
using LibraryHouse.Infrastructure.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LibraryHouse.Application.Companies
{
    public class CompanyService : ICompanyService
    {
        private readonly ILogger<CompanyService> _logger;
        private readonly IMapper _mapper;
        private readonly IRepository<Company> _companyRepository;
        private readonly IRepository<BookCompany> _bookCompanyRepository;

        public CompanyService(
            ILogger<CompanyService> logger,
            IMapper mapper,
            IRepository<Company> companyRepository,
            IRepository<BookCompany> bookCompanyRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _companyRepository = companyRepository;
            _bookCompanyRepository = bookCompanyRepository;
        }

        public async Task Create(CreateCompanyDto createCompanyDto)
        {
            var existingCompany = await _companyRepository
                .GetAll()
                .AnyAsync(x => x.Name == createCompanyDto.Name);

            if (existingCompany)
            {
                _logger.LogError($"Company with name: {createCompanyDto.Name} already exist.");
                throw new CustomUserFriendlyException("This company is already registered. Please try again with another one!");
            }

            var newCompany = _mapper.Map<Company>(createCompanyDto);

            await _companyRepository.AddAsync(newCompany);
        }

        public async Task<CompanyDto> GetById(int companyId)
        {
            var user = await _companyRepository.GetAsync(companyId);

            if (user == null)
            {
                _logger.LogError($"Unable to find company with Id: {companyId}.");
                throw new CustomUserFriendlyException($"Unable to find company with Id: {companyId}!");
            }

            return _mapper.Map<CompanyDto>(user);
        }

        public async Task<List<CompanyDto>> GetAll()
        {
            var companies = await _companyRepository
                .GetAll()
                .ToListAsync();

            return _mapper.Map<List<CompanyDto>>(companies);
        }

        public async Task Delete(int companyId)
        {
            var company = await _companyRepository.GetAsync(companyId);

            if (company == null)
            {
                _logger.LogError($"Unable to find company with Id: {companyId} and delete it.");
                throw new CustomUserFriendlyException($"Unable to find company and delete it!");
            }

            _companyRepository.Delete(company);
        }

        public async Task AddCompanyForBook(int bookId, int companyId)
        {
            var existingBookCompany = await _bookCompanyRepository
                .GetAll()
                .AnyAsync(x => x.BookId == bookId && x.CompanyId == companyId);

            if (existingBookCompany)
            {
                _logger.LogError($"Unable to add company with Id: {companyId} to book with Id: {bookId} because relation already exist.");
                throw new CustomUserFriendlyException("Company with this book already exist!");
            }

            var newBookCompany = new BookCompany
            {
                BookId = bookId,
                CompanyId = companyId
            };

            await _bookCompanyRepository.AddAsync(newBookCompany);
        }

        public async Task RemoveCompanyFromBook(int bookId, int companyId)
        {
            var existingBookCompany = await _bookCompanyRepository
                .GetAll()
                .FirstOrDefaultAsync(x => x.BookId == bookId && x.CompanyId == companyId);

            if (existingBookCompany == null)
            {
                _logger.LogError($"Unable to remove company with Id: {companyId} from book with Id: {bookId} because relation don't exist.");
                throw new CustomUserFriendlyException("Book with this company already don't exist!");
            }

            _bookCompanyRepository.Delete(existingBookCompany);
        }
    }
}
