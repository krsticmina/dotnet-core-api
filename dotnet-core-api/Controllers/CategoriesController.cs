using AutoMapper;
using dotnet_core_api.Contracts.V1;
using dotnet_core_api.Dtos;
using dotnet_core_api.ExceptionHandling.Exceptions;
using dotnet_core_api.Interfaces;
using dotnet_core_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_core_api.Controllers
{
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        [HttpPost(ApiRoutesV1.Categories.AddCategory)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddCategory([FromBody] CreateCategoryDto createCategoryRequest) 
        {
            var category = mapper.Map<CreateCategoryModel>(createCategoryRequest);

            var createCategoryResponse = await categoryService.AddCategoryAsync(category);

            return Ok(createCategoryResponse);
        }

        [HttpDelete(ApiRoutesV1.Categories.DeleteCategoryById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCategoryById(int categoryId)
        {
            var category = await categoryService.DeleteCategoryByIdAsync(categoryId);

            return Ok(category);

        }


        [HttpDelete(ApiRoutesV1.Categories.DeleteCategoryByName)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCategoryByName(string categoryName)
        {
            var category = await categoryService.DeleteCategoryByNameAsync(categoryName);

            return Ok(category);
        }

    }
}
