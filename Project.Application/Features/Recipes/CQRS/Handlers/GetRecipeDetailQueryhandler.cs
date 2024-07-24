using AutoMapper;
using Project.Application.Contracts.Persistence;
using Project.Application.Features.Recipes.CQRS.Queries;
using Project.Application.Features.Recipes.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Application.Features.Recipes.CQRS.Handlers
{
    public class GetRecipeDetailQueryHandler : IRequestHandler<GetRecipeDetailQuery, RecipeDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRecipeDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<RecipeDto> Handle(GetRecipeDetailQuery request, CancellationToken cancellationToken)
        {
            var recipe = await _unitOfWork.RecipeRepository.Get(request.Id);
            return _mapper.Map<RecipeDto>(recipe);
        }
    }
}