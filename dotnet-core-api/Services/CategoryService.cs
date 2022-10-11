﻿using AutoMapper;
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

        public async Task<CategoryModel?> AddCategoryAsync(CategoryToAddModel newCategory)
        {

            var categoryDb = await categoryRepository.GetCategoryByNameAsync(newCategory.Name);

            if (categoryDb != null)
            {
                return null;
            }

            var category = mapper.Map<Category>(newCategory);

            await categoryRepository.AddCategoryAsync(category);

            await categoryRepository.SaveChangesAsync();

            return mapper.Map<CategoryModel>(category);

        }

    }
}
