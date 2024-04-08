using InventoryManagementSystem.Dtos;

namespace InventoryManagementSystem.Services.Interfaces;

/// <summary>
/// Interface for searching items.
/// </summary>
public interface IItemSearchService
{
    /// <summary>
    /// Searches for items asynchronously based on the provided search criteria.
    /// </summary>
    /// <param name="criteria">The criteria to use for searching items.</param>
    /// <returns>A collection of items matching the search criteria.</returns>
    Task<IEnumerable<ItemDto>> SearchItemsAsync(ItemSearchCriteriaDto criteria);
}
