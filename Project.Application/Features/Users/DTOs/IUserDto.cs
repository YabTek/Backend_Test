using System;

namespace Project.Application.Features.Users_.DTOs
{
    public interface IUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
