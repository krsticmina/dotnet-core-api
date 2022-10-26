using AutoMapper;
using dotnet_core_api.Data.Entities;
using dotnet_core_api.Dtos;
using dotnet_core_api.Models;

namespace dotnet_core_api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegistrationRequest, UserRegistrationModel>();
        }
    }
}
