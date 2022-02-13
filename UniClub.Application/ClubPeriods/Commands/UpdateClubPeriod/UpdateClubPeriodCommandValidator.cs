using FluentValidation;

namespace UniClub.Application.ClubPeriods.Commands.UpdateClubPeriod
{
    public class UpdateClubPeriodCommandValidator : AbstractValidator<UpdateClubPeriodCommand>
    {
        public UpdateClubPeriodCommandValidator()
        {
            RuleFor(c => c.ClubId)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .GreaterThan(0).WithMessage("{PropertyName} is invalid");

            RuleFor(c => c.StartDate)
                .NotEmpty().WithMessage("{PropertyName} is not valid date");

            RuleFor(c => c.EndDate)
            .NotEmpty().WithMessage("{PropertyName} is not valid date");

            RuleFor(c => c.Status)
                .IsInEnum().WithMessage("{PropertyName} is invalid");
        }
    }
}
