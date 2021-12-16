using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using LibraryHouse.Application.Dtos.Books;
using LibraryHouse.Application.Helpers;

namespace LibraryHouse.Application.Validators.Books
{
    public class UpdateBookDtoValidator : AbstractValidator<UpdateBookDto>
    {
        public UpdateBookDtoValidator()
        {
            RuleFor(x => x.BookType)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Book type is required!"))
                .MaximumLength(64).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length of book type is 64 symbols!"));
        }
    }
}
