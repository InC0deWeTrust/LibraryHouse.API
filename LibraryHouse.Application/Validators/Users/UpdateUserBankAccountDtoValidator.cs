using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using LibraryHouse.Application.Dtos.Users;
using LibraryHouse.Application.Helpers;

namespace LibraryHouse.Application.Validators.Users
{
    public class UpdateUserBankAccountDtoValidator : AbstractValidator<UpdateUserBankAccountDto>
    {
        public UpdateUserBankAccountDtoValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Password is required!"))
                .MaximumLength(64).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length is 64 symbols!"));

            RuleFor(x => x.BankAccount)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Bank Account is required!"));
        }
    }
}
