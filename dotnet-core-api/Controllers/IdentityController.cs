using AutoMapper;
using dotnet_core_api.Contracts.V1;
using dotnet_core_api.Dtos;
using dotnet_core_api.Interfaces;
using dotnet_core_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_core_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IIdentityService identityService;

        public IdentityController(IMapper mapper, IIdentityService identityService)
        {
            this.mapper = mapper;
            this.identityService = identityService;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost(ApiRoutesV1.Identity.Register)]
        public async Task<IActionResult> Register([FromBody]UserRegistrationRequest userRegistrationRequest) 
        {
            var user = mapper.Map<UserRegistrationModel>(userRegistrationRequest);

            var userRegistrationResponse = await identityService.RegisterUser(user);

            if (!userRegistrationResponse.Succeeded)
            {
                foreach (var error in userRegistrationResponse.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }

        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost(ApiRoutesV1.Identity.Login)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest userLoginRequest)
        {
            var user = mapper.Map<UserLoginModel>(userLoginRequest);

            var userLoginResponse = await identityService.ValidateUser(user);

            if (!userLoginResponse)
            {
                return Unauthorized("Wrong username/password.");
            }

            var token = await identityService.CreateToken();

            return Ok( new { Token = token });

        }
    }
}
