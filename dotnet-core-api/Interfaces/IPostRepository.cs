using dotnet_core_api.Data.Entities;

namespace dotnet_core_api.Interfaces
{
    public interface IPostRepository
    {

        /// <summary>
        /// Asynchronous method for adding a post to database
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        Task AddPostAsync(Post post);

        /// <summary>
        /// Asynchronous method for getting a post from database using post Id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        Task<Post?> GetPostByIdAsync(int postId);

        /// <summary>
        /// Method for deleting a post from database
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        void DeletePost(Post post);

        /// <summary>
        /// Asynchronous method for saving changes made to database
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveChangesAsync();
    }
}
