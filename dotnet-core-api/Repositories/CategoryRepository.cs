using dotnet_core_api.Data.DbContexts;
using dotnet_core_api.Data.Entities;
using dotnet_core_api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dotnet_core_api.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BlogDatabaseContext context;

        public CategoryRepository(BlogDatabaseContext context)
        {
            this.context = context;
        }

        public async Task AddCategoryAsync(Category category)
        {
            await context.Categories.AddAsync(category);
        }

        public async Task<Category?> GetCategoryByNameAsync(string name)
        {
            return await context.Categories.Where(c => c.Name == name).FirstOrDefaultAsync();
        }

        public void DeleteCategory(Category category)
        {
            var categoryToDelete = context.Categories.Find(category.Id);
            context.Categories.Remove(categoryToDelete);

        }

        public async Task<Category?> GetCategoryByIdAsync(int categoryId)
        {
            return await context.Categories.Where(c => c.Id == categoryId).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() >= 0;
        }
    }
}
