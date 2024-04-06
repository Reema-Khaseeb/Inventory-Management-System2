using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Dtos;

namespace InventoryManagementSystem.Services.Interfaces
{
    public interface IItemService
    {
        Task<Item> CreateItemAsync(Item newItem);
        void UpdateItemStatus(Item item);
    }
}