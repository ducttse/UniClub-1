using FluentValidation;
using System;
using System.Linq;

namespace UniClub.Application.ClubRoles.Commands.CreateClubRole
{
    public class CreateClubRoleCommandValidator : AbstractValidator<CreateClubRoleCommand>
    {
        public CreateClubRoleCommandValidator()
        {
            RuleFor(c => c.ClubId)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .GreaterThan(0).WithMessage("{PropertyName} is invalid");

            RuleFor(c => c.Role)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 50).WithMessage("Length {PropertyName} must between 2 and 50")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(c => c.ClubPeriodId)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .GreaterThan(0).WithMessage("{PropertyName} is invalid");

            RuleFor(c => c.ReportToRoleId)
                 .GreaterThan(0).WithMessage("{PropertyName} is invalid");

        }

        protected bool BeAValidName(string name)
        {
            name = name.Replace("  ", "");
            name = name.Replace("-", "");
            return name.All(Char.IsLetter);
        }
    }
}
