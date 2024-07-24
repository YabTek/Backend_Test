using FluentValidation;
using Project.Application.Features.Comments.DTOs;

namespace Project.Application.Features.Comments.Validators
{
    public class UpdateCommentDtoValidator : AbstractValidator<UpdateCommentDto>
    {
        public UpdateCommentDtoValidator()
        {
            Include(new ICommentDtoValidator());

            RuleFor(project => project.Id)
                .GreaterThan(0).WithMessage("Project ID must be a positive number.");
        }
    }
}
