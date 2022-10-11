using AutoMapper;
using dotnet_core_api.Data.Entities;
using dotnet_core_api.Dtos;
using dotnet_core_api.Models;

namespace dotnet_core_api.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() 
        {
            CreateMap<CategoryForCreationDto, CategoryToAddModel>();
            CreateMap<CategoryToAddModel, Category>();
            CreateMap<Category, CategoryModel>();
        }
    }
}
