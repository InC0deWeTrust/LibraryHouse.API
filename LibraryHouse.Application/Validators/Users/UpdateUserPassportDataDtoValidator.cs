using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using LibraryHouse.Application.Dtos.Users;
using LibraryHouse.Application.Helpers;

namespace LibraryHouse.Application.Validators.Users
{
    public class UpdateUserPassportDataDtoValidator : AbstractValidator<UpdateUserPassportDataDto>
    {
        public UpdateUserPassportDataDtoValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Password is required!"))
                .MaximumLength(64).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length of password is 64 symbols!"));

            RuleFor(x => x.PassportData)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Passport Data is required!"))
                .MaximumLength(12).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length of passport data is 12 symbols!"));
        }
    }
}
