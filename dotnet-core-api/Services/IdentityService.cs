using AutoMapper;
using dotnet_core_api.Data.Entities;
using dotnet_core_api.Interfaces;
using dotnet_core_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace dotnet_core_api.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly ILoggerManager logger;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private User _user;

        public IdentityService(ILoggerManager logger, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IMapper mapper)
        {
            this.logger = logger;
            this.userManager = userManager;
            this.roleManager = roleManager;
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

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "User");
            }

            return result;  
        }

        public async Task<bool> ValidateUser(UserLoginModel userLoginModel)
        {
            _user = await userManager.FindByNameAsync(userLoginModel.UserName);

            var result = (_user != null && await userManager.CheckPasswordAsync(_user, userLoginModel.Password));

            if (!result) 
            {
                logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed. Wrong user name or password.");
            }

            return result;
        }

        public async Task<string> CreateToken()
        {
            var userRoles = await userManager.GetRolesAsync(_user);

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, _user.UserName),
                    new Claim(ClaimTypes.Email, _user.Email),
                    new Claim("Id", _user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JwtAuthentication:SecretForKey"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JwtAuthentication:Issuer"],
                audience: configuration["JwtAuthentication:Audience"],
                expires: DateTime.Now.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
