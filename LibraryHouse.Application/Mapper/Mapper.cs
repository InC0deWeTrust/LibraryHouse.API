using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using AutoMapper;
using LibraryHouse.Application.Dtos.Authors;
using LibraryHouse.Application.Dtos.Books;
using LibraryHouse.Application.Dtos.Companies;
using LibraryHouse.Application.Dtos.Roles;
using LibraryHouse.Application.Dtos.Users;
using LibraryHouse.Infrastructure.Entities.Authors;
using LibraryHouse.Infrastructure.Entities.Books;
using LibraryHouse.Infrastructure.Entities.Companies;
using LibraryHouse.Infrastructure.Entities.Roles;
using LibraryHouse.Infrastructure.Entities.Users;

namespace LibraryHouse.Application.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            //Author
            CreateMap<AuthorDto, Author>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.AuthorId))
                .ReverseMap();

            //Book
            CreateMap<BookDto, Book>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.BookId))
                .ReverseMap();
            CreateMap<CreateBookDto, Book>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(x => x.BookType));
            CreateMap<Book, FullInfoBookDto>()
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(x => x.Id));
            CreateMap<BookType, BookTypeDto>()
                .ForMember(dest => dest.TypeId, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.BookType, opt => opt.MapFrom(x => x.Type));

            //Company
            CreateMap<CompanyDto, Company>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.CompanyId))
                .ReverseMap();
            CreateMap<CreateCompanyDto, Company>();

            //Role
            CreateMap<RoleDto, Role>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.RoleId))
                .ReverseMap();
            CreateMap<CreateRoleDto, Role>();

            //User
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.UserId))
                .ReverseMap();
            CreateMap<CreateUserDto, User>();
        }
    }
}
