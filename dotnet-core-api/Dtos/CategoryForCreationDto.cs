using System.ComponentModel.DataAnnotations;

namespace dotnet_core_api.Dtos
{
    public class CategoryForCreationDto
    {
        [Required(ErrorMessage = "You should provide a name value.")]
        public String Name { get; set; } 
    }
}
