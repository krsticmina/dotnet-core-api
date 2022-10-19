using AutoMapper;
using dotnet_core_api.Data.Entities;
using dotnet_core_api.Dtos;
using dotnet_core_api.Models;

namespace dotnet_core_api.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
 
            CreateMap<CreatePostDto, CreatePostModel>();
            CreateMap<CreatePostModel, Post>();
            CreateMap<Post, PostModel>();
            CreateMap<UpdatePostDto, UpdatePostModel>();
            CreateMap<UpdatePostModel, Post>().ReverseMap();
        }
    }

}
