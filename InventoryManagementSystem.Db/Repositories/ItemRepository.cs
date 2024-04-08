using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Db.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Db.Repositories;
public class ItemRepository : IItemRepository
{
    private readonly InventoryManagementSystemDbContext _dbContext;

    public ItemRepository(InventoryManagementSystemDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<Item> CreateItemAsync(Item item)
    {
        _dbContext.Items.Add(item);
        await _dbContext.SaveChangesAsync();

        return item;
    }

    public async Task UpdateItemAsync(Item item)
    {
        _dbContext.Items.Update(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteItemAsync(Item item)
    {
        _dbContext.Items.Remove(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Item> GetItemByIdAsync(int itemId)
    {
        return await _dbContext.Items.FindAsync(itemId);
    }

    public async Task<IEnumerable<Item>> GetItemsAsync()
    {
        return await _dbContext.Items.ToListAsync();
    }

    public IQueryable<Item> GetQueryableItems()
    {
        return _dbContext.Items;
    }
}
