using AutoMapper;
using dotnet_core_api.Data.Entities;
using dotnet_core_api.ExceptionHandling.Exceptions;
using dotnet_core_api.Interfaces;
using dotnet_core_api.Models;

namespace dotnet_core_api.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public PostService(IPostRepository postRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.postRepository = postRepository;
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<PostModel?> AddPostAsync(CreatePostModel createPostModel, string userId)
        {

            var category = await categoryRepository.GetCategoryByIdAsync(createPostModel.CategoryId);

            if (category == null)
            {
                throw new CategoryNotFoundException($"Category with Id {createPostModel.CategoryId} could not be found.");
            }

            var post = mapper.Map<Post>(createPostModel);

            post.CreatedById = userId;

            await postRepository.AddPostAsync(post);

            await postRepository.SaveChangesAsync();

            return mapper.Map<PostModel>(post);
        }

        public async Task<PostModel?> DeletePostByIdAsync(int postId, string userId)
        {
            var post = await postRepository.GetPostByIdAsync(postId);

            if (post == null)
            {
                throw new PostNotFoundException($"Post with Id {postId} does not exist.");
            }

            if (!post.CreatedById.Equals(userId)) 
            {
                throw new UnauthorizedAccessException("You can't delete a post made by another user.");
            }

            postRepository.DeletePost(post);

            await postRepository.SaveChangesAsync();

            return mapper.Map<PostModel>(post);

        }

        public async Task<PostModel?> GetPostByIdAsync(int postId)
        {
            var post = await postRepository.GetPostByIdAsync(postId);

            if (post == null)
            {
                throw new PostNotFoundException($"Post with Id {postId} does not exist.");
            }

            return mapper.Map<PostModel>(post);

        }

        public async Task UpdatePostAsync(int postId, UpdatePostModel updatePostModel, string userId)
        {
            var post = await postRepository.GetPostByIdAsync(postId);

            if (post == null)
            {
                throw new PostNotFoundException($"Post with Id {postId} does not exist.");
            }

            if (!post.CreatedById.Equals(userId))
            {
                throw new UnauthorizedAccessException("You can't update a post made by another user.");
            }

            mapper.Map(updatePostModel, post);

            await postRepository.SaveChangesAsync();
        }
    }
}
