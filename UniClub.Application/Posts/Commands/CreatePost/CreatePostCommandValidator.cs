﻿using FluentValidation;
using UniClub.Application.Common;

namespace UniClub.Application.Posts.Commands.CreatePost
{
    public class CreatePostCommandValidator : UniClubAbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(e => e.PersonId)
                .NotEmpty().WithMessage("{PropertyName} is not empty");

            RuleFor(e => e.Content)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 2000).WithMessage("Length {PropertyName} must between 2 and 2000")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(e => e.ShortDescription)
                .NotEmpty().WithMessage("{PropertyName} is not empty")
                .Length(2, 1000).WithMessage("Length {PropertyName} must between 2 and 1000")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(e => e.Status)
                .IsInEnum();
        }
    }
}