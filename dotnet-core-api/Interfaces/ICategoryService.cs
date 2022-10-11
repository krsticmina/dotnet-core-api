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
        Task<CategoryModel?> AddCategoryAsync(CategoryToAddModel newCategory);
    }
}
