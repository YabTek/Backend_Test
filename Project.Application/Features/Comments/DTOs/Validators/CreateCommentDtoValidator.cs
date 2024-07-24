using FluentValidation;
using Project.Application.Features.Comments.DTOs;

namespace Project.Application.Features.Comments.Validators
{
    public class CreateCommentDtoValidator : AbstractValidator<CreateCommentDto>
    {
        public CreateCommentDtoValidator()
        {
            Include(new ICommentDtoValidator());

        }
    }
}
