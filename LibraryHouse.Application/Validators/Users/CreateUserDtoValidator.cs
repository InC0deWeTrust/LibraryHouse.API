﻿using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using LibraryHouse.Application.Dtos.Users;
using LibraryHouse.Application.Helpers;

namespace LibraryHouse.Application.Validators.Users
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "First name is required!"))
                .MaximumLength(64).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length of first name is 64 symbols!"));

            RuleFor(x => x.LastName)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Last name is required!"))
                .MaximumLength(64).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length of last name is 64 symbols!"));

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

            RuleFor(x => x.Address)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Address is required!"))
                .MaximumLength(128).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length of address is 128 symbols!"));

            RuleFor(x => x.PassportData)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Passport Data is required!"))
                .MaximumLength(12).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length of passport data is 12 symbols!"));

            RuleFor(x => x.TelephoneNumber)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Telephone Number is required!"))
                .MinimumLength(10).OnFailure(
                    x => throw new CustomUserFriendlyException(
                "Min length of phone number is 10 symbols!"))
                .MaximumLength(10).OnFailure(
                x => throw new CustomUserFriendlyException(
                    "Min length of phone number is 10 symbols!"));

        }
    }
}
