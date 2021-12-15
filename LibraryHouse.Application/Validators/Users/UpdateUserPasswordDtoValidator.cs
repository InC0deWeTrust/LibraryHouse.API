using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using LibraryHouse.Application.Dtos.Users;
using LibraryHouse.Application.Helpers;

namespace LibraryHouse.Application.Validators.Users
{
    public class UpdateUserPasswordDtoValidator : AbstractValidator<UpdateUserPasswordDto>
    {
        public UpdateUserPasswordDtoValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "This should be an email!"))
                .MaximumLength(64).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length is 64 symbols!"));

            RuleFor(x => x.OldPassword)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Old Password is required!"));

            RuleFor(x => x.NewPassword)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "New Password is required!"))
                .MaximumLength(64).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length is 64 symbols!"));
        }
    }
}
