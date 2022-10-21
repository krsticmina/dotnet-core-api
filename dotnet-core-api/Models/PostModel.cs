namespace dotnet_core_api.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public int CreatedById { get; set; }
        public int CategoryId { get; set; }

    }
}
