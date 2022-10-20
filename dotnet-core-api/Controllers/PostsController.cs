using AutoMapper;
using dotnet_core_api.Contracts.V1;
using dotnet_core_api.Dtos;
using dotnet_core_api.ExceptionHandling.Exceptions;
using dotnet_core_api.Interfaces;
using dotnet_core_api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace dotnet_core_api.Controllers
{
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService service;
        private readonly IMapper mapper;

        public PostsController(IPostService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet(ApiRoutesV1.Posts.GetPostById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [BusinessExceptionFilter(typeof(PostNotFoundException), HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetPostById(int postId)
        {
            var post = await service.GetPostByIdAsync(postId);

            return Ok(post);
        }

        [HttpPost(ApiRoutesV1.Posts.AddPost)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [BusinessExceptionFilter(typeof(CategoryNotFoundException), HttpStatusCode.NotFound)]
        public async Task<IActionResult> AddPost([FromBody] CreatePostRequest createPostRequest) 
        {
            var post = mapper.Map<CreatePostModel>(createPostRequest);

            var createPostResponse = await service.AddPostAsync(post);

            return Ok(createPostResponse);
        }

        [HttpPut(ApiRoutesV1.Posts.UpdatePost)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [BusinessExceptionFilter(typeof(PostNotFoundException), HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdatePost(int postId, UpdatePostRequest updatePostRequest)
        {
            var post = mapper.Map<UpdatePostModel>(updatePostRequest);
            
            await service.UpdatePostAsync(postId, post);

            return Ok();
        }


        [HttpDelete(ApiRoutesV1.Posts.DeletePostById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [BusinessExceptionFilter(typeof(PostNotFoundException), HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteCategoryById(int postId)
        {
            var post = await service.DeletePostByIdAsync(postId);

            return Ok(post);

        }
    }
}
