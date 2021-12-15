using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryHouse.Application.Dtos.Companies;

namespace LibraryHouse.Application.Companies
{
    public interface ICompanyService
    {
        Task Create(CreateCompanyDto createCompanyDto);

        Task<CompanyDto> GetById(int companyId);

        Task<List<CompanyDto>> GetAll();

        Task Delete(int companyId);

        Task AddCompanyForBook(int bookId, int companyId);

        Task RemoveCompanyFromBook(int bookId, int companyId);
    }
}
