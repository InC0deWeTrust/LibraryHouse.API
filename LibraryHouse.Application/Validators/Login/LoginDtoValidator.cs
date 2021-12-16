using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using LibraryHouse.Application.Dtos.Login;
using LibraryHouse.Application.Helpers;

namespace LibraryHouse.Application.Validators.Login
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Email is required!"))
                .MaximumLength(64).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length of email is 64 symbols!"));

            RuleFor(x => x.Password)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Password is required!"))
                .MaximumLength(64).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length of password is 64 symbols!"));
        }
    }
}
