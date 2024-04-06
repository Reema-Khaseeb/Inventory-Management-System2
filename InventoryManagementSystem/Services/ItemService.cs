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
}
