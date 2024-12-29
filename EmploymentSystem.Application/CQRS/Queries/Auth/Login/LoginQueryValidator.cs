using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace EmploymentSystem.Application.Queries.Auth.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(s => s.UserName).NotEmpty().WithMessage("UserName is required");
            RuleFor(s => s.Password).NotEmpty().WithMessage("Password is required");

        }
    }
}
