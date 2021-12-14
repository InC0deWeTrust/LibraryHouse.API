using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using LibraryHouse.Application.Dtos.Authors;
using LibraryHouse.Application.Dtos.Books;
using LibraryHouse.Application.Dtos.Companies;
using LibraryHouse.Application.Dtos.Roles;
using LibraryHouse.Application.Dtos.Users;
using LibraryHouse.Application.Models.Authors;
using LibraryHouse.Application.Models.Books;
using LibraryHouse.Application.Models.Companies;
using LibraryHouse.Application.Models.Roles;
using LibraryHouse.Application.Models.Users;
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
            //CHANGE SUBJECT TO DTOS
            //Author
            CreateMap<AuthorDto, Author>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.AuthorId))
                .ReverseMap();

            //Book
            CreateMap<BookDto, Book>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.BookId))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(x => x.BookType))
                .ReverseMap();
            CreateMap<CreateBookDto, Book>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(x => x.BookType));
                //.ForMember(dest => dest.)

            //Company
            CreateMap<CompanyDto, Company>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.CompanyId))
                .ReverseMap();

            //Role
            CreateMap<RoleDto, Role>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.RoleId))
                .ReverseMap();
            CreateMap<CreateRoleDto, Role>();

            //TODO: THINK OF WAY TO PREVENT PASSWORD POP UP USING THIS DTO IF POSSIBLE
            //User
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.UserId))
                .ReverseMap();
            CreateMap<CreateUserDto, User>();
        }
    }
}
