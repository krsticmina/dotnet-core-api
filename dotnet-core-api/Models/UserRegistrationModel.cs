﻿namespace dotnet_core_api.Models
{
    public class UserRegistrationModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public ICollection<string>? Roles { get; set; }

    }
}
