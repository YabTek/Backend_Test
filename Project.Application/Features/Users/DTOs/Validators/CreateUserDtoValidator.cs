using FluentValidation;
using Project.Application.Features.Users_.DTOs;

namespace Project.Application.Features.Users_.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            Include(new IUserDtoValidator());
            
        }
    }
}
