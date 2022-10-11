using dotnet_core_api.Data.Entities;

namespace dotnet_core_api.Interfaces
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Asynchronous method for adding a category to database
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task AddCategoryAsync(Category category);
        /// <summary>
        /// Asynchronous method for saving changes made to database
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveChangesAsync();

        /// <summary>
        /// Asynchronous method for getting a category from database using Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Category?> GetCategoryByNameAsync(string name);


        /// <summary>
        /// Asynchronous method for getting a category from database using Id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<Category?> GetCategoryByIdAsync(int categoryId);

        /// <summary>
        /// Method for deleting a category from database
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        void DeleteCategory(Category category);

    }
}
