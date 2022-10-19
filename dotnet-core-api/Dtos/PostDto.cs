namespace dotnet_core_api.Dtos
{
    public class PostDto
    {
        public int PostId { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int CreatedById { get; set; }
        public int CategoryId { get; set; }
    }
}
