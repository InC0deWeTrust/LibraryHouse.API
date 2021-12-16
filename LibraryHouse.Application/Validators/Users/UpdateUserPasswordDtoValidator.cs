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
                        "Email is required!"))
                .MaximumLength(64).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length of email is 64 symbols!"));

            RuleFor(x => x.OldPassword)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Old Password is required in order to change for new one!"));

            RuleFor(x => x.NewPassword)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "New Password is required in order to replace your old one!"))
                .MaximumLength(64).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length of new password is 64 symbols!"));
        }
    }
}
