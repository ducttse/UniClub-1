using FluentValidation;
using System;
using UniClub.Domain.Common;
using UniClub.Dtos.Update;

namespace UniClub.Commands.Update.Validators
{
    public class UpdateClubPeriodCommandValidator : UniClubAbstractValidator<UpdateClubPeriodDto>
    {
        public UpdateClubPeriodCommandValidator()
        {
            RuleFor(c => c.ClubId)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .GreaterThan(0).WithMessage("{PropertyName} is invalid");

            RuleFor(c => c.StartDate)
                .NotNull().WithMessage("{PropertyName} is not null")
                .GreaterThan(default(DateTime)).WithMessage("{PropertyName} is not valid date");

            RuleFor(c => c.EndDate)
            .NotNull().WithMessage("{PropertyName} is not null")
            .GreaterThan(c => c.StartDate).WithMessage("{PropertyName} is not valid date");

            RuleFor(c => c.Status)
                .IsInEnum().WithMessage("{PropertyName} is invalid");
        }
    }
}
