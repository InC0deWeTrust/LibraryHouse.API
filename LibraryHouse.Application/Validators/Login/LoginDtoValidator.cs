﻿using System;
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
                        "This should be an email!"))
                .MaximumLength(64).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length is 64 symbols!"));

            RuleFor(x => x.Password)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Password is required!"))
                .MaximumLength(64).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length is 64 symbols!"));
        }
    }
}
