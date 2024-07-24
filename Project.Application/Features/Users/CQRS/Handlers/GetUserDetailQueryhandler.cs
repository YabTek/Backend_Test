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
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.Get(request.Id);
            return _mapper.Map<UserDto>(user);
        }
    }
}