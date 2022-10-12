using dotnet_core_api.Models;

namespace dotnet_core_api.Interfaces
{
    public interface ICategoryService
    {
        /// <summary>
        /// Asynchronous service method for adding an employee.
        /// </summary>
        /// <param name="newCategory"></param>
        /// <returns></returns>
        Task<CategoryModel?> AddCategoryAsync(CreateCategoryModel createCategoryRequest);

        /// <summary>
        /// Asynchronous service method for deleting a category using categoryId
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<CategoryModel?> DeleteCategoryByIdAsync(int categoryId);

        /// <summary>
        ///  Asynchronous service method for deleting a category using category name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<CategoryModel?> DeleteCategoryByNameAsync(string categoryName);

    }
}
