using InventoryManagementSystem.Common.Enums;
using InventoryManagementSystem.Db.Models;

namespace InventoryManagementSystem.Db.Extensions;

/// <summary>
/// Provides extension methods for querying items with specific criteria.
/// </summary>
public static class ItemQueryExtensions
{
    /// <summary>
    /// Filters items by name or description containing the search term.
    /// </summary>
    /// <param name="query">The queryable item collection.</param>
    /// <param name="searchTerm">The search term to match.</param>
    /// <returns>The filtered item collection.</returns>
    public static IQueryable<Item> WithNameOrDescription(this IQueryable<Item> query, string searchTerm)
    {
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(item =>
                item.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                item.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }
        return query;
    }

    /// <summary>
    /// Filters items by category.
    /// </summary>
    /// <param name="query">The queryable item collection.</param>
    /// <param name="categoryId">The category ID to match.</param>
    /// <returns>The filtered item collection.</returns>
    public static IQueryable<Item> InCategory(this IQueryable<Item> query, int? categoryId)
    {
        if (categoryId.HasValue)
        {
            query = query.Where(item => item.CategoryId == categoryId.Value);
        }
        return query;
    }

    /// <summary>
    /// Filters items by status.
    /// </summary>
    /// <param name="query">The queryable item collection.</param>
    /// <param name="status">The status to match.</param>
    /// <returns>The filtered item collection.</returns>
    public static IQueryable<Item> WithStatus(this IQueryable<Item> query, ItemStatus? status)
    {
        if (status.HasValue)
        {
            query = query.Where(item => item.Status == status.Value);
        }
        return query;
    }

    /// <summary>
    /// Filters items by quantity range.
    /// </summary>
    /// <param name="query">The queryable item collection.</param>
    /// <param name="minQuantity">The minimum quantity.</param>
    /// <param name="maxQuantity">The maximum quantity.</param>
    /// <returns>The filtered item collection.</returns>
    public static IQueryable<Item> WithinQuantityRange(this IQueryable<Item> query, int? minQuantity, int? maxQuantity)
    {
        if (minQuantity.HasValue)
        {
            query = query.Where(item => item.Quantity >= minQuantity.Value);
        }

        if (maxQuantity.HasValue)
        {
            query = query.Where(item => item.Quantity <= maxQuantity.Value);
        }

        return query;
    }
}
