using FluentValidation;
using UniClub.Application.Common;

namespace UniClub.Application.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandValidator : UniClubAbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidator()
        {
            RuleFor(e => e.UniId)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .GreaterThan(0).WithMessage("{PropertyName} is invalid");

            RuleFor(e => e.ShortName)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 10).WithMessage("Length {PropertyName} must between 2 and 10")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(e => e.DepName)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 256).WithMessage("Length {PropertyName} must between 2 and 256")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");
        }
    }
}
