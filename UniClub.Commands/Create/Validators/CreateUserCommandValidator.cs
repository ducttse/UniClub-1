using FluentValidation;
using System;
using UniClub.Application;
using UniClub.Dtos.Create;

namespace UniClub.Commands.Create.Validators
{
    public class CreateUserCommandValidator : UniClubAbstractValidator<CreateUserDto>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(e => e.UserName)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 256).WithMessage("Length {PropertyName} must between 2 and 256")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(e => e.Name)
               .NotEmpty().WithMessage("{PropertyName} is not empty")
               .Length(2, 256).WithMessage("Length {PropertyName} must between 2 and 256")
               .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(e => e.Password)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(4, 30).WithMessage("Length {PropertyName} must between 4 and 30");

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .EmailAddress().WithMessage("{PropertyName is invalid}");

            RuleFor(e => e.DepId)
                .GreaterThan(0).WithMessage("{PropertyName is invalid}");

            RuleFor(e => e.DateOfBirth)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .GreaterThan(default(DateTime)).WithMessage("{PropertyName is invalid}")
                .LessThan(DateTime.UtcNow.AddYears(-18)).WithMessage("{PropertyName is invalid}");
        }
    }
}
