using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using LibraryHouse.Application.Dtos.Companies;
using LibraryHouse.Application.Helpers;

namespace LibraryHouse.Application.Validators.Companies
{
    public class CreateCompanyDtoValidator : AbstractValidator<CreateCompanyDto>
    {
        public CreateCompanyDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Name of the company is required!"))
                .MaximumLength(64).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length of company name is 64 symbols!"));
        }
    }
}
