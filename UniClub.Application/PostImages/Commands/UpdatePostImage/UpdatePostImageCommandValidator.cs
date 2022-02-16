using FluentValidation;
using UniClub.Application.Common;

namespace UniClub.Application.PostImages.Commands.UpdatePostImage
{
    public class UpdatePostImageCommandValidator : UniClubAbstractValidator<UpdatePostImageCommand>
    {
        public UpdatePostImageCommandValidator()
        {
            RuleFor(e => e.PostId)
               .NotEmpty().WithMessage("{PropertyName} is not empty")
               .GreaterThan(0).WithMessage("{PropertyName} is invalid");
        }
    }
}
