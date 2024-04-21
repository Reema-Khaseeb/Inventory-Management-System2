using AutoMapper;
using InventoryManagementSystem.Db.Extensions;
using InventoryManagementSystem.Db.Repositories.Interfaces;
using InventoryManagementSystem.Dtos;
using InventoryManagementSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InventoryManagementSystem.Services;

/// <summary>
/// Service for searching items based on various criteria.
/// </summary>
public class ItemSearchService : IItemSearchService
{
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<ItemSearchService> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ItemSearchService"/> class.
    /// </summary>
    /// <param name="itemRepository">The item repository.</param>
    /// <param name="mapper">The mapper for converting between entities and DTOs.</param>
    public ItemSearchService(IItemRepository itemRepository,
        IMapper mapper, ILogger<ItemSearchService> logger)
    {
        _itemRepository = itemRepository;
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    }

    /// <summary>
    /// Searches items based on provided criteria.
    /// </summary>
    /// <param name="criteria">The search criteria.</param>
    /// <returns>A collection of items that match the search criteria.</returns>
    public async Task<IEnumerable<ItemDto>> SearchItemsAsync(ItemSearchCriteriaDto criteria)
    {
        var query = _itemRepository.GetQueryableItems();

        // Apply filters from the criteria
        query = query.WithNameOrDescription(criteria.SearchTerm)
                     .InCategory(criteria.CategoryId)
                     .WithStatus(criteria.Status)
                     .WithinQuantityRange(criteria.MinQuantity, criteria.MaxQuantity);

        var items = await query.ToListAsync();
        _logger.LogInformation("{Count} items found matching criteria", items.Count);

        // Convert Item entities to ItemDto objects
        return items.Select(item => _mapper.Map<ItemDto>(item)).ToList();
    }
}
