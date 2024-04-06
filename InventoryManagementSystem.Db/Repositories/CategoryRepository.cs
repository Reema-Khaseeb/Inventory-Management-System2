using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Db.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Db.Repositories;
public class CategoryRepository : ICategoryRepository
{
    private readonly InventoryManagementSystemDbContext _dbContext;

    public CategoryRepository(InventoryManagementSystemDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<Category> CreateCategoryAsync(Category category)
    {
        _dbContext.Categories.Add(category);
        await _dbContext.SaveChangesAsync();

        return category;
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        _dbContext.Categories.Update(category);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteCategoryAsync(Category category)
    {
        _dbContext.Categories.Remove(category);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int categoryId)
    {
        return await _dbContext.Categories.FindAsync(categoryId);
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _dbContext.Categories.ToListAsync();
    }

    public async Task<bool> IsCategoryExistAsync(int categoryId)
    {
        return await _dbContext.Categories.AnyAsync(c => c.Id == categoryId);
    }
}
