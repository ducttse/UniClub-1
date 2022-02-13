using FluentValidation;

namespace UniClub.Application.ClubPeriods.Commands.CreateClubPeriod
{
    public class CreateClubPeriodCommandValidator : AbstractValidator<CreateClubPeriodCommand>
    {
        public CreateClubPeriodCommandValidator()
        {
            RuleFor(c => c.ClubId)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .GreaterThan(0);

            RuleFor(c => c.StartDate)
                .NotEmpty().WithMessage("{PropertyName} is not valid date");

            RuleFor(c => c.EndDate)
            .NotEmpty().WithMessage("{PropertyName} is not valid date");

            RuleFor(c => c.Status)
                .IsInEnum().WithMessage("{PropertyName} is invalid");
        }
    }
}
