using FluentValidation;
using UniClub.Application.Common;

namespace UniClub.Application.ClubTasks.Commands.UpdateClubTask
{
    public class UpdateClubTaskCommandValidator : UniClubAbstractValidator<UpdateClubTaskCommand>
    {
        public UpdateClubTaskCommandValidator()
        {

            RuleFor(e => e.EventId)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .GreaterThan(0).WithMessage("{PropertyName} is invalid");

            RuleFor(e => e.StartDate)
                .Must(BeAPresentDate).WithMessage("{PropertyName} is invalid");

            RuleFor(e => e.EndDate)
                .Must(BeAFutureDate).WithMessage("{PropertyName} is invalid");

            RuleFor(e => e.Status)
                .IsInEnum().WithMessage("{PropertyName} is invalid");

            RuleFor(e => e.TaskName)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 100).WithMessage("Length {PropertyName} must between 2 and 100")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(e => e.Description)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 256).WithMessage("Length {PropertyName} must between 2 and 256")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");
        }
    }
}
