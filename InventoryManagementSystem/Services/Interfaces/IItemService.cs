using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Dtos;

namespace InventoryManagementSystem.Services.Interfaces
{
    public interface IItemService
    {
        Task<Item> CreateItemAsync(Item newItem);
        Task<Item> GetItemAsync(int id);
        Task<IEnumerable<Item>> GetItemsAsync();
        Task UpdateItemAsync(int id, ItemDto itemDto);
        Task DeleteItemAsync(int id);
        void UpdateItemStatus(Item item);
    }
}