namespace Project.Application.Features.Users_.DTOs
{
    public class CreateUserDto : IUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
