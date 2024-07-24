using AutoMapper;
using Project.Application.Contracts.Persistence;
using Project.Application.Features.Users_.CQRS.Queries;
using Project.Application.Features.Users_.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Application.Features.Users_.CQRS.Handlers
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.UserRepository.GetAll();
            return _mapper.Map<List<UserDto>>(users);
        }
    }
}