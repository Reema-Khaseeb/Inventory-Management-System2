using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Dtos;

namespace InventoryManagementSystem.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> CreateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
        Task UpdateCategoryAsync(int id, CategoryDto categoryDto);
    }
}