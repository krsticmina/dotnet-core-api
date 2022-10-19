using dotnet_core_api.Data.DbContexts;
using dotnet_core_api.Data.Entities;
using dotnet_core_api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dotnet_core_api.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDatabaseContext context;

        public PostRepository(BlogDatabaseContext dbContext)
        {
            this.context = dbContext;
        }

        public async Task AddPostAsync(Post post)
        {
            await context.Posts.AddAsync(post);
        }

        public void DeletePost(Post post)
        {
            var postToDelete = context.Posts.Find(post.Id);

            context.Posts.Remove(postToDelete);
        }

        public async Task<Post?> GetPostByIdAsync(int postId)
        {
            return await context.Posts.Where(p => p.Id == postId).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() >= 0;
        }
    }
}
