using dotnet_core_api.Models;
using Microsoft.AspNetCore.Identity;

namespace dotnet_core_api.Interfaces
{
    public interface IIdentityService
    {
        Task<IdentityResult> RegisterUser(UserRegistrationModel userRegistrationModel);
    }
}
