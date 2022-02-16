using FluentValidation;
using UniClub.Application.Common;

namespace UniClub.Application.PostImages.Commands.CreatePostImage
{
    public class CreatePostImageCommandValidator : UniClubAbstractValidator<CreatePostImageCommand>
    {
        public CreatePostImageCommandValidator()
        {
            RuleFor(e => e.PostId)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .GreaterThan(0).WithMessage("{PropertyName} is invalid");
        }
    }
}
