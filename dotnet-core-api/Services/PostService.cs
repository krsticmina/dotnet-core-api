﻿using AutoMapper;
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

        public async Task<PostModel?> AddPostAsync(CreatePostModel createPostModel)
        {

            var category = await categoryRepository.GetCategoryByIdAsync(createPostModel.CategoryId);

            if (category == null)
            {
                throw new CategoryNotFoundException($"Category with Id {createPostModel.CategoryId} could not be found.");
            }

            var post = mapper.Map<Post>(createPostModel);

            await postRepository.AddPostAsync(post);

            await postRepository.SaveChangesAsync();

            return mapper.Map<PostModel>(post);
        }

        public async Task<PostModel?> DeletePostByIdAsync(int postId)
        {
            var post = await postRepository.GetPostByIdAsync(postId);

            if (post == null)
            {
                throw new PostNotFoundException($"Post with Id {postId} does not exist.");
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

        public async Task UpdatePostAsync(int postId, UpdatePostModel updatePostModel)
        {
            var post = await postRepository.GetPostByIdAsync(postId);

            if (post == null)
            {
                throw new PostNotFoundException($"Post with Id {postId} does not exist.");
            }

            mapper.Map(updatePostModel, post);

            await postRepository.SaveChangesAsync();
        }
    }
}
