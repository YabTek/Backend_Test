using System;
using Project.Application.Features.Common;

namespace Project.Application.Features.Users_.DTOs
{
    public class UserDto : BaseDto, IUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
