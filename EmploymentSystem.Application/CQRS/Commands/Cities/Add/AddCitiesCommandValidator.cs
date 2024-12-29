// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using FluentValidation;

namespace EmploymentSystem.Application.Commands
{

    public class AddCitiesCommandValidator : AbstractValidator<AddCitiesCommand>
    {
        public AddCitiesCommandValidator()
        {
            RuleFor(i => i.obj.Code).NotEmpty().NotNull().WithMessage("Code  is required");
        }
    }

}
