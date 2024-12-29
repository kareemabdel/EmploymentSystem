// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using FluentValidation;

namespace EmploymentSystem.Application.Commands
{

    public class AddVaccancyCommandValidator : AbstractValidator<AddVaccancyCommand>
    {
        public AddVaccancyCommandValidator()
        {
            RuleFor(i => i.obj.MaxApplications).NotEmpty().NotNull().WithMessage("MaxApplications  is required");
        }
    }

}
