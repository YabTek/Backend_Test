using Project.Application.Features.Common;

namespace Project.Application.Features.Users_.DTOs
{
    public class UpdateUserDto : BaseDto, IUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; } 
    }
}
