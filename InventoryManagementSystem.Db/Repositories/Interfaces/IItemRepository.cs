using InventoryManagementSystem.Db.Models;

namespace InventoryManagementSystem.Db.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Task<Item> CreateItemAsync(Item item);
        Task DeleteItemAsync(Item item);
        Task<Item> GetItemByIdAsync(int itemId);
        Task<IEnumerable<Item>> GetItemsAsync();
        Task UpdateItemAsync(Item item);
    }
}