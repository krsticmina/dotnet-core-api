using System.ComponentModel.DataAnnotations;

namespace dotnet_core_api.Dtos
{
    public class UserLoginRequest
    {
        [Required(ErrorMessage = "You must enter a username.")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "You must enter a password.")]
        public string? Password { get; set; }
    }
}
