using InventoryManagementSystem.Common.Enums;

namespace InventoryManagementSystem.Dtos
{
    /// <summary>
    /// Represents criteria for searching items.
    /// </summary>
    public record ItemSearchCriteriaDto(
        /// <summary>
        /// Gets or sets the search term, that might be an item name or description
        /// </summary>
        string? SearchTerm,

        /// <summary>
        /// Gets or sets the category ID.
        /// </summary>
        int? CategoryId,

        /// <summary>
        /// Gets or sets the item status.
        /// </summary>
        ItemStatus? Status,

        /// <summary>
        /// Gets or sets the minimum quantity.
        /// </summary>
        int? MinQuantity,

        /// <summary>
        /// Gets or sets the maximum quantity.
        /// </summary>
        int? MaxQuantity
    );
}
