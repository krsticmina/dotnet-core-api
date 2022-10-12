using dotnet_core_api.Models;

namespace dotnet_core_api.Interfaces
{
    public interface ICategoryService
    {

        /// <summary>
        /// Asynchronous service method for adding a category 
        /// </summary>
        /// <param name="createCategoryRequest"></param>
        /// <returns></returns>
        Task<CategoryModel?> AddCategoryAsync(CreateCategoryModel createCategoryRequest);

        /// <summary>
        /// Asynchronous service method for deleting a category using categoryId
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<CategoryModel?> DeleteCategoryByIdAsync(int categoryId);


        /// <summary>
        /// Asynchronous service method for deleting a category using category name
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        Task<CategoryModel?> DeleteCategoryByNameAsync(string categoryName);

    }
}
