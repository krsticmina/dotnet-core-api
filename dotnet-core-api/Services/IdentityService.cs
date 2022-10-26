using AutoMapper;
using dotnet_core_api.Data.Entities;
using dotnet_core_api.Interfaces;
using dotnet_core_api.Models;
using Microsoft.AspNetCore.Identity;
namespace dotnet_core_api.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public IdentityService(UserManager<User> userManager, IConfiguration configuration, IMapper mapper)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        public async Task<IdentityResult> RegisterUser(UserRegistrationModel userRegistrationModel)
        {
            User user = new()
            {
                Email = userRegistrationModel.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = userRegistrationModel.UserName
            };

            var result = await userManager.CreateAsync(user, userRegistrationModel.Password);

            return result;  
        }
    }
}
