using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using LibraryHouse.Application.Dtos.Books;
using LibraryHouse.Application.Helpers;

namespace LibraryHouse.Application.Validators.Books
{
    public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
    {
        public CreateBookDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Name of the book is required!"))
                .MaximumLength(64).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length is 64 symbols!"));

            RuleFor(x => x.BookType)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Book type is required!"))
                .MaximumLength(30).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length is 30 symbols!"));

            RuleFor(x => x.AuthorName)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Author name is required!"))
                .MaximumLength(64).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length is 64 symbols!"));

            RuleFor(x => x.AuthorSurname)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Author surname is required!"))
                .MaximumLength(64).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length is 64 symbols!"));
        }
    }
}
