using InventoryManagementSystem.Db.Models;

namespace InventoryManagementSystem.Db.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategoryAsync(Category category);
        Task DeleteCategoryAsync(Category category);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int categoryId);
        Task UpdateCategoryAsync(Category category);
        Task<bool> IsCategoryExistAsync(int categoryId);
    }
}