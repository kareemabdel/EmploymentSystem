// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using FluentValidation;

namespace EmploymentSystem.Application.Commands
{

    public class UpdateApplicationUserCommandValidator : AbstractValidator<UpdateApplicationUserCommand>
    {
        public UpdateApplicationUserCommandValidator()
        {
            RuleFor(i => i.obj.Id).NotEqual(Guid.Empty).WithMessage("Id can't be null");
            RuleFor(i => i.obj.Email).NotEmpty().WithMessage("Email address is required")
                                 .EmailAddress().WithMessage("A valid email is required");
            RuleFor(i => i.obj.UserName).NotEmpty().WithMessage("UserName is required");
            RuleFor(i => i.obj.Phone).NotEmpty().WithMessage("Phone is required");
            RuleFor(i => i.obj.Name).NotEmpty().WithMessage("Name is required");


        }
    }

}
