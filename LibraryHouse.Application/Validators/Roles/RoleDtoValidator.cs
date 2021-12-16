using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using LibraryHouse.Application.Dtos.Roles;
using LibraryHouse.Application.Helpers;

namespace LibraryHouse.Application.Validators.Roles
{
    public class RoleDtoValidator : AbstractValidator<RoleDto>
    {
        public RoleDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Role name is required!"))
                .MaximumLength(64).OnFailure(
                    x => throw new CustomUserFriendlyException(
                        "Max length of role name is 64 symbols!"));
        }
    }
}
