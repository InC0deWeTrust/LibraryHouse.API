﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryHouse.Application.Companies;
using LibraryHouse.Application.Dtos.Companies;

namespace LibraryHouse.Web.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task CreateCompany(CreateCompanyDto createCompanyDto)
        {
            await _companyService.Create(createCompanyDto);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<CompanyDto> GetCompanyById(int companyId)
        {
            return await _companyService.GetById(companyId);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<List<CompanyDto>> GetAllCompanies()
        {
            return await _companyService.GetAll();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task DeleteCompany(int companyId)
        {
            await _companyService.Delete(companyId);
        }
    }
}