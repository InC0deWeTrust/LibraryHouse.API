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
            ////TODO: REMOVE ALL EXISTING MODELS AND REPLACE THEM WITH DTOS
            ////Roles
            //CreateMap<RoleModel, Role>()
            //    .ReverseMap();
            //CreateMap<CreateRoleDto, RoleModel>();
            //CreateMap<RoleDto, RoleModel>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.RoleId))
            //    .ReverseMap();
            //CreateMap<Role, RoleDto>()
            //    .ForMember(dest => dest.RoleId, opt => opt.MapFrom(x => x.Id));

            ////Users
            //CreateMap<UserModel, User>()
            //    .ReverseMap();
            //CreateMap<CreateUserDto, UserModel>();
            //CreateMap<UpdateUserBankAccountDto, UserModel>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.UserId));
            //CreateMap<UpdateUserDto, UserModel>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.UserId));
            //CreateMap<UpdateUserPassportDataDto, UserModel>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.UserId));
            //CreateMap<UpdateUserPasswordDto, UserModel>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.UserId));
            //CreateMap<UserDto, UserModel>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.UserId))
            //    .ReverseMap();

            ////Books
            //CreateMap<BookModel, Book>()
            //    .ReverseMap();
            ////TODO: AND THIS ONE ALSO CHECK
            //CreateMap<BookDto, BookModel>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.BookId))
            //    .ForMember(dest => dest.Type, opt => opt.MapFrom(x => x.BookType))
            //    .ReverseMap();
            ////TODO: CHECK IF THIS GONNA WORK
            //CreateMap<CreateBookDto, BookModel>()
            //    .ForMember(dest => dest.Type, opt => opt.MapFrom(x => x.BookType));
            //CreateMap<UpdateBookDto, BookModel>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.BookId))
            //    .ForMember(dest => dest.Type, opt => opt.MapFrom(x => x.BookType));

            ////Companies
            //CreateMap<CompanyModel, Company>()
            //    .ReverseMap();
            //CreateMap<CompanyDto, CompanyModel>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.CompanyId))
            //    .ReverseMap();
            //CreateMap<CreateCompanyDto, CompanyModel>();

            ////Authors
            //CreateMap<AuthorModel, AuthorModel>()
            //    .ReverseMap();
            //CreateMap<AuthorDto, AuthorModel>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.AuthorId))
            //    .ReverseMap();
            //CreateMap<CreateAuthorDto, AuthorModel>();


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
