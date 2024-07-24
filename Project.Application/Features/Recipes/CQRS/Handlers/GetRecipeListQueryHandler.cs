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
    public class GetRecipeListQueryHandler : IRequestHandler<GetRecipeListQuery, List<RecipeDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRecipeListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<RecipeDto>> Handle(GetRecipeListQuery request, CancellationToken cancellationToken)
        {
            var recipes = await _unitOfWork.RecipeRepository.GetAll();
            return _mapper.Map<List<RecipeDto>>(recipes);
        }
    }
}