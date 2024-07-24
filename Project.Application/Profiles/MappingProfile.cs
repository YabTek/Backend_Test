using AutoMapper;
using Project.Application.Features.Recipes.DTOs;
using Project.Application.Features.Comments.DTOs;
using Project.Application.Features.Users_.DTOs;
using Project.Application.Models.Identity;
using Project.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Recipe, RecipeDto>().ReverseMap();
            CreateMap<Recipe, CreateRecipeDto>().ReverseMap();

            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Comment, CreateCommentDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();


           CreateMap<RegisterDto, RegistrationRequest>().ReverseMap();
           CreateMap<RegisterDto, RegistrationResponse>().ReverseMap();
        }
    }
}
