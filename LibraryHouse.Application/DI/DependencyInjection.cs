﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FluentValidation.AspNetCore;
using LibraryHouse.Application.Auth;
using LibraryHouse.Application.Authors;
using LibraryHouse.Application.Books;
using LibraryHouse.Application.Companies;
using LibraryHouse.Application.Roles;
using LibraryHouse.Application.Users;
using LibraryHouse.Application.Validators.Login;
using LibraryHouse.Infrastructure.DI;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryHouse.Application.DI
{
    public static class DependencyInjection
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginDtoValidator>());
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.RegisterInfrastructureServices();
        }
    }
}
