using AutoMapper;
using InventoryManagementSystem.Common.Enums;
using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Db.Repositories.Interfaces;
using InventoryManagementSystem.Dtos;
using InventoryManagementSystem.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace InventoryManagementSystem.Services;
public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;
    private readonly IUserRepository _userRepository;
    private readonly ILogger<ItemService> _logger;
    private readonly IMapper _mapper;

    public ItemService(
        IItemRepository itemRepository,
        IUserRepository userRepository,
        ILogger<ItemService> logger,
        IMapper mapper
        )
    {
        _itemRepository = itemRepository;
        _userRepository = userRepository;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new item asynchronously.
    /// </summary>
    /// <param name="newItem">The new item to create.</param>
    /// <returns>The created item.</returns>
    /// <exception cref="ArgumentNullException">Thrown if newItem is null.</exception>
    /// <exception cref="KeyNotFoundException">Thrown if the specified user or category does not exist.</exception>
    public async Task<Item> CreateItemAsync(Item newItem)
    {
        ArgumentNullException.ThrowIfNull(newItem, nameof(newItem));

        try
        {
            // Validate foreign keys
            var userExists = await _userRepository.IsUserExistAsync(newItem.UserId);
            if (!userExists)
            {
                _logger.LogError($"User with ID {newItem.UserId} not found.");
                throw new KeyNotFoundException($"User with ID {newItem.UserId} not found.");
            }

            UpdateItemStatus(newItem);

            var createdItem = await _itemRepository.CreateItemAsync(newItem);
            _logger.LogInformation($"Inventory Item {createdItem.Id} created successfully.");
            return createdItem;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while creating a new item.");
            throw;
        }
    }

    /// <summary>
    /// Retrieves a single item by its ID.
    /// </summary>
    /// <param name="id">The ID of the item to retrieve.</param>
    /// <returns>The requested item if found.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the item is not found.</exception>
    public async Task<Item> GetItemAsync(int id)
    {
        try
        {
            var item = await _itemRepository.GetItemByIdAsync(id);

            if (item == null)
            {
                _logger.LogWarning($"Item with ID {id} not found.");
                throw new KeyNotFoundException($"Item with ID {id} not found.");
            }

            _logger.LogInformation($"Item with ID {id} successfully retrieved.");
            return item;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while attempting to retrieve item with ID {id}.");
            throw;
        }
    }

    /// <summary>
    /// Retrieves all items.
    /// </summary>
    /// <returns>A collection of all items.</returns>
    public async Task<IEnumerable<Item>> GetItemsAsync()
    {
        var items = await _itemRepository.GetItemsAsync();
        _logger.LogInformation("All Items successfully retrieved.");
        return items;
    }

    /// <summary>
    /// Updates an item based on provided data.
    /// </summary>
    /// <param name="id">The ID of the item to update.</param>
    /// <param name="itemDto">The data transfer object containing update data.</param>
    /// <exception cref="KeyNotFoundException">Thrown if the item, specified user, or category does not exist.</exception>
    public async Task UpdateItemAsync(int id, ItemDto itemDto)
    {
        try
        {
            var existingItem = await GetItemAsync(id);

            // Validate foreign keys
            if (itemDto.UserId.HasValue
                && !await _userRepository.IsUserExistAsync(itemDto.UserId.Value))
            {
                var errorMsg = $"User with ID {itemDto.UserId} not found.";
                _logger.LogError(errorMsg);
                throw new KeyNotFoundException(errorMsg);
            }

            _mapper.Map(itemDto, existingItem);
            UpdateItemStatus(existingItem);

            await _itemRepository.UpdateItemAsync(existingItem);
            _logger.LogInformation($"Item with ID: {id} has been successfully updated.");
        }
        catch (KeyNotFoundException knfEx)
        {
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                $"An unexpected error occurred while attempting to update the item with ID: {id}.");
            throw;
        }
    }

    /// <summary>
    /// Updates the status of an item based on its quantity.
    /// </summary>
    /// <param name="item">The item whose status needs to be updated.</param>
    public void UpdateItemStatus(Item item)
    {
        item.Status = item.Quantity switch
        {
            <= 0 => ItemStatus.OutOfStock,
            <= 20 => ItemStatus.LowStock,
            _ => ItemStatus.InStock
        };
    }
}
