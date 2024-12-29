﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using FluentValidation;

namespace EmploymentSystem.Application.Commands
{

    public class UpdateVaccancyCommandValidator : AbstractValidator<UpdateVaccancyCommand>
    {
        public UpdateVaccancyCommandValidator()
        {
            RuleFor(i => i.obj.Id).NotEqual(Guid.Empty).WithMessage("Id can't be null");
        }
    }

}
