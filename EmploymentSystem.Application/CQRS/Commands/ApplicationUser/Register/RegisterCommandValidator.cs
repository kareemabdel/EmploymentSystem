// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using FluentValidation;

namespace EmploymentSystem.Application.Commands
{

    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(i => i.obj.Email).NotEmpty().WithMessage("Email address is required").EmailAddress().WithMessage("A valid email is required");
            RuleFor(i => i.obj.UserName).NotEmpty().WithMessage("UserName address is required");    
            RuleFor(s => s.obj.Password).NotEmpty().WithMessage("Password is required");     
            RuleFor(s => s.obj.Phone).NotEmpty().WithMessage("Phone is required");     
            RuleFor(s => s.obj.Name).NotEmpty().WithMessage("Name is required");     
        }
    }

}
