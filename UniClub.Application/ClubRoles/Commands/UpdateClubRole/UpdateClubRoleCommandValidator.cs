using FluentValidation;
using UniClub.Application.Common;

namespace UniClub.Application.ClubRoles.Commands.UpdateClubRole
{
    public class UpdateClubRoleCommandValidator : UniClubAbstractValidator<UpdateClubRoleCommand>
    {
        public UpdateClubRoleCommandValidator()
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
        }
    }
}
