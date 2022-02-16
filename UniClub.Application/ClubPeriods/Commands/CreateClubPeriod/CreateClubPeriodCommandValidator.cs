﻿using FluentValidation;
using System;
using UniClub.Application.Common;

namespace UniClub.Application.ClubPeriods.Commands.CreateClubPeriod
{
    public class CreateClubPeriodCommandValidator : UniClubAbstractValidator<CreateClubPeriodCommand>
    {
        public CreateClubPeriodCommandValidator()
        {
            RuleFor(c => c.ClubId)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .GreaterThan(0);

            RuleFor(c => c.StartDate)
                .NotEmpty().WithMessage("{PropertyName} is not valid date")
                .GreaterThan(default(DateTime)).WithMessage("{PropertyName} is not valid date");

            RuleFor(c => c.EndDate)
            .NotNull().WithMessage("{PropertyName} is not valid date")
            .GreaterThan(c => c.StartDate).WithMessage("{PropertyName} is not valid date");

            RuleFor(c => c.Status)
                .IsInEnum().WithMessage("{PropertyName} is invalid");
        }
    }
}
