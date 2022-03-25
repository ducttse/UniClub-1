using FluentValidation;
using System;
using UniClub.Application;
using UniClub.Dtos.Update;

namespace UniClub.Commands.Update.Validators
{
    public class UpdateUserCommandValidator : UniClubAbstractValidator<UpdateUserDto>
    {
        public UpdateUserCommandValidator()
        {

            RuleFor(e => e.Name)
               .NotEmpty().WithMessage("{PropertyName} is not empty")
               .Length(2, 256).WithMessage("Length {PropertyName} must between 2 and 256")
               .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(e => e.Password)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(4, 30).WithMessage("Length {PropertyName} must between 4 and 30");

            RuleFor(e => e.DepId)
                .GreaterThan(0).WithMessage("{PropertyName is invalid}");

            RuleFor(e => e.DateOfBirth)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .GreaterThan(default(DateTime)).WithMessage("{PropertyName is invalid}")
                .LessThan(DateTime.UtcNow.AddYears(-18)).WithMessage("{PropertyName is invalid}");
        }
    }
}
