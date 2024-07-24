using Project.Application.Features.Users_.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Application.Features.Users_.CQRS.Queries
{
    public class GetUserDetailQuery : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}