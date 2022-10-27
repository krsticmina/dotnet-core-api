using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dotnet_core_api.Data.Entities
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.UtcNow;

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey("CreatedById")]
        public string CreatedById { get; set; }
        public User User { get; set; }


    }

}
