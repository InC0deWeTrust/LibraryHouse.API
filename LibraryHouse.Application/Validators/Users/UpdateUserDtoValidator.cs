using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using LibraryHouse.Application.Dtos.Users;
using LibraryHouse.Application.Helpers;

namespace LibraryHouse.Application.Validators.Users
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "First name is required!"))
                .MaximumLength(64).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length is 64 symbols!"));

            RuleFor(x => x.LastName)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Last name is required!"))
                .MaximumLength(64).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length is 64 symbols!"));

            RuleFor(x => x.Email)
                .EmailAddress().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "This should be an email!"))
                .MaximumLength(64).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length is 64 symbols!"));

            RuleFor(x => x.Address)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Address is required!"))
                .MaximumLength(64).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length is 64 symbols!"));

            RuleFor(x => x.TelephoneNumber)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Telephone Number is required!"))
                .MinimumLength(10).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Min length is 10 symbols!"))
                .MaximumLength(10).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Min length is 10 symbols!"));
        }
    }
}
