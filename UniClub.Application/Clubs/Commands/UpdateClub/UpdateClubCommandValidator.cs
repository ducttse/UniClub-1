using FluentValidation;
using UniClub.Application.Common;

namespace UniClub.Application.Clubs.Commands.UpdateClub
{
    public class UpdateClubCommandValidator : UniClubAbstractValidator<UpdateClubCommand>
    {
        public UpdateClubCommandValidator()
        {
            RuleFor(e => e.ClubName)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 256).WithMessage("Length {PropertyName} must between 2 and 256")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(e => e.ShortName)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 10).WithMessage("Length {PropertyName} must between 2 and 10")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(e => e.Description)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 400).WithMessage("Length {PropertyName} must between 2 and 400")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(e => e.ShortDescription)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 100).WithMessage("Length {PropertyName} must between 2 and 100")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(e => e.Slogan)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 256).WithMessage("Length {PropertyName} must between 2 and 256")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(e => e.UniId)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .GreaterThan(0).WithMessage("{PropertyName} is invalid");
        }
    }
}
