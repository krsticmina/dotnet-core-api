using System.ComponentModel.DataAnnotations;

namespace dotnet_core_api.Dtos
{
    public class CreatePostRequest
    {
        [Required(ErrorMessage = "The text field cannot be empty.")]
        public string Text { get; set; }
        [Required]
        public int? CategoryId { get; set; }
    }
}
