using AutoMapper;
using dotnet_core_api.Contracts.V1;
using dotnet_core_api.Data.Entities;
using dotnet_core_api.Dtos;
using dotnet_core_api.Interfaces;
using dotnet_core_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

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
        public async Task<IActionResult> AddCategory([FromBody] CategoryForCreationDto categoryToAdd) 
        {
            var category = mapper.Map<CategoryToAddModel>(categoryToAdd);

            var newCategory = await categoryService.AddCategoryAsync(category);

            if (newCategory == null) return BadRequest($"Category with name {category.Name} already exists in the database");

            return Ok(newCategory);
        }



    }
}
