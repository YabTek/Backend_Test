using FluentValidation;
using Project.Application.Features.Users_.DTOs;

namespace Project.Application.Features.Users_.Validators
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            Include(new IUserDtoValidator());
            
            RuleFor(user => user.Id).NotNull().WithMessage("{PropertyName} must be present");


                    }
    }
}
