using AutoMapper;
using dotnet_core_api.Data.Entities;
using dotnet_core_api.Interfaces;
using dotnet_core_api.Models;

namespace dotnet_core_api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<CategoryModel?> AddCategoryAsync(CreateCategoryModel createCategoryRequest)
        {

            var categoryDb = await categoryRepository.GetCategoryByNameAsync(createCategoryRequest.Name);

            if (categoryDb != null)
            {
                return null;
            }

            var createCategoryResponse = mapper.Map<Category>(createCategoryRequest);

            await categoryRepository.AddCategoryAsync(createCategoryResponse);

            await categoryRepository.SaveChangesAsync();

            return mapper.Map<CategoryModel>(createCategoryResponse);

        }

        public async Task<CategoryModel?> DeleteCategoryByIdAsync(int categoryId)
        {
            var category = await categoryRepository.GetCategoryByIdAsync(categoryId);

            if (category == null)
            {
                return null;
            }

            categoryRepository.DeleteCategory(category);

            await categoryRepository.SaveChangesAsync();

            return mapper.Map<CategoryModel>(category);

        }

        public async Task<CategoryModel?> DeleteCategoryByNameAsync(string categoryName)
        {
            var category = await categoryRepository.GetCategoryByNameAsync(categoryName);

            if (category == null)
            {
                return null;
            }

            categoryRepository.DeleteCategory(category);

            await categoryRepository.SaveChangesAsync();

            return mapper.Map<CategoryModel>(category);

        }



    }
}
