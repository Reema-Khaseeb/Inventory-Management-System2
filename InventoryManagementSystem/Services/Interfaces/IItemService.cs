using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Dtos;

namespace InventoryManagementSystem.Services.Interfaces
{
    /// <summary>
    /// Interface for interacting with items.
    /// </summary>
    public interface IItemService
    {
        /// <summary>
        /// Creates a new item asynchronously.
        /// </summary>
        /// <param name="newItem">The item to create.</param>
        /// <returns>The created item.</returns>
        Task<Item> CreateItemAsync(Item newItem);

        /// <summary>
        /// Retrieves an item by its identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the item to retrieve.</param>
        /// <returns>The retrieved item.</returns>
        Task<Item> GetItemAsync(int id);

        /// <summary>
        /// Retrieves all items asynchronously.
        /// </summary>
        /// <returns>A collection of items.</returns>
        Task<IEnumerable<Item>> GetItemsAsync();

        /// <summary>
        /// Updates an item asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the item to update.</param>
        /// <param name="itemDto">The DTO containing updated item information.</param>
        Task UpdateItemAsync(int id, ItemDto itemDto);

        /// <summary>
        /// Deletes an item asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the item to delete.</param>
        Task DeleteItemAsync(int id);

        /// <summary>
        /// Updates the status of an item.
        /// </summary>
        /// <param name="item">The item whose status to update.</param>
        void UpdateItemStatus(Item item);
    }
}
