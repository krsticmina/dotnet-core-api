using dotnet_core_api.Data.Entities;
using dotnet_core_api.Interfaces;
using dotnet_core_api.Data.DbContexts;
using Microsoft.EntityFrameworkCore.Internal;
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

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() >= 0;
        }
    }
}
