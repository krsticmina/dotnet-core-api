using dotnet_core_api.Models;

namespace dotnet_core_api.Interfaces
{
    public interface IPostService
    {
        /// <summary>
        /// Asynchronous service method for adding a post 
        /// </summary>
        /// <param name="createPostRequest"></param>
        /// <returns></returns>
        Task<PostModel?> AddPostAsync(CreatePostModel createPostRequest, string userId);

        /// <summary>
        /// Asynchronous service method for deleting a post using post Id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        Task<PostModel?> DeletePostByIdAsync(int postId, string userId);

        /// <summary>
        /// Asynchronous service method for getting a post using post Id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        Task<PostModel?> GetPostByIdAsync(int postId);


        /// <summary>
        /// Asynchronous service method for updating a post 
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="updatePostRequest"></param>
        /// <returns></returns>
        Task UpdatePostAsync(int postId, UpdatePostModel updatePostRequest, string userId);
    }
}
