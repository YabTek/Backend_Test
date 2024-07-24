using FluentValidation;
using System;
using Project.Application.Features.Comments.DTOs;


namespace Project.Application.Features.Comments.DTOs
{
    public class ICommentDtoValidator : AbstractValidator<ICommentDto>
    {
        public ICommentDtoValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.")
                .MaximumLength(1000).WithMessage("Content cannot exceed 1000 characters.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date is required.");

            RuleFor(x => x.RecipeId)
                .GreaterThan(0).WithMessage("RecipeId must be a positive integer.");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be a positive integer.");
        }

        
    }
}
