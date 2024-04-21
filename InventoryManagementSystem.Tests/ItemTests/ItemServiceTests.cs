using AutoMapper;
using FluentAssertions;
using InventoryManagementSystem.Common.Enums;
using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Db.Repositories.Interfaces;
using InventoryManagementSystem.Dtos;
using InventoryManagementSystem.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace InventoryManagementSystem.Tests.ItemTests;

public class ItemServiceTests
{
    private readonly Mock<IItemRepository> _mockItemRepository;
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly Mock<ICategoryRepository> _mockCategoryRepository;
    private readonly Mock<ILogger<ItemService>> _mockLogger;
    private readonly Mock<IMapper> _mockMapper;
    private readonly ItemService _itemService;

    public ItemServiceTests()
    {
        _mockItemRepository = new Mock<IItemRepository>();
        _mockUserRepository = new Mock<IUserRepository>();
        _mockCategoryRepository = new Mock<ICategoryRepository>();
        _mockLogger = new Mock<ILogger<ItemService>>();
        _mockMapper = new Mock<IMapper>();

        _itemService = new ItemService(_mockItemRepository.Object, _mockUserRepository.Object,
                                       _mockCategoryRepository.Object, _mockLogger.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task CreateItemAsync_ShouldCreateItem_WhenValid()
    {
        // Arrange
        var newItem = new Item { Id = 1, UserId = 1, CategoryId = 1 };
        _mockUserRepository.Setup(x => x.IsUserExistAsync(newItem.UserId)).ReturnsAsync(true);
        _mockCategoryRepository.Setup(x => x.IsCategoryExistAsync(newItem.CategoryId)).ReturnsAsync(true);
        _mockItemRepository.Setup(x => x.CreateItemAsync(It.IsAny<Item>())).ReturnsAsync(newItem);

        // Setup logger for success messages
        _mockLogger.Setup(x => x.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("created successfully")),
            null,
            It.IsAny<Func<It.IsAnyType, Exception, string>>()))
        .Verifiable("Failed to log information correctly");

        // Act
        var result = await _itemService.CreateItemAsync(newItem);

        // Assert
        Assert.NotNull(result);
        _mockLogger.Verify(); // Ensure the correct logging happened
    }

    [Fact]
    public async Task CreateItemAsync_ShouldThrowKeyNotFoundException_WhenUserDoesNotExist()
    {
        // Arrange
        var newItem = new Item { UserId = 99, CategoryId = 1 };
        _mockUserRepository.Setup(x => x.IsUserExistAsync(newItem.UserId)).ReturnsAsync(false);

        // Setup logger for error messages
        _mockLogger.Setup(x => x.Log(
            LogLevel.Error,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("not found") || v.ToString().Contains("Database error")),
            It.IsAny<Exception>(),
            It.IsAny<Func<It.IsAnyType, Exception, string>>()))
        .Verifiable("Failed to log error correctly");

        // Act
        Func<Task> act = async () => await _itemService.CreateItemAsync(newItem);

        // Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(act);
        _mockLogger.Verify(); // Ensure the error was logged as expected
    }


    [Fact]
    public async Task CreateItemAsync_ShouldThrowKeyNotFoundException_WhenCategoryDoesNotExist()
    {
        // Arrange
        var newItem = new Item { UserId = 1, CategoryId = 99 }; // Non-existent category ID
        _mockUserRepository.Setup(x => x.IsUserExistAsync(newItem.UserId)).ReturnsAsync(true);
        _mockCategoryRepository.Setup(x => x.IsCategoryExistAsync(newItem.CategoryId)).ReturnsAsync(false);

        // Setup logger to verify error logging
        _mockLogger.Setup(x => x.Log(
            LogLevel.Error,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Category with ID 99 not found")),
            It.IsAny<Exception>(),
            It.IsAny<Func<It.IsAnyType, Exception, string>>()))
        .Verifiable();

        // Act
        Func<Task> act = async () => await _itemService.CreateItemAsync(newItem);

        // Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(act);
        _mockLogger.Verify(); // Ensure the error was logged as expected
    }

    [Fact]
    public async Task CreateItemAsync_ShouldHandleExceptionsProperly()
    {
        // Arrange
        var newItem = new Item { Id = 1, UserId = 1, CategoryId = 1 };
        _mockUserRepository.Setup(x => x.IsUserExistAsync(newItem.UserId)).ReturnsAsync(true);
        _mockCategoryRepository.Setup(x => x.IsCategoryExistAsync(newItem.CategoryId)).ReturnsAsync(true);
        _mockItemRepository.Setup(x => x.CreateItemAsync(It.IsAny<Item>())).ThrowsAsync(new Exception("Database error"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _itemService.CreateItemAsync(newItem));
    }

    [Fact]
    public async Task GetItemAsync_ShouldReturnItem_WhenItemExists()
    {
        // Arrange
        var itemId = 1;
        var expectedItem = new Item { Id = itemId, Name = "Test Item" };
        _mockItemRepository.Setup(repo => repo.GetItemByIdAsync(itemId)).ReturnsAsync(expectedItem);

        // Setup logger to verify information logging
        _mockLogger.Setup(x => x.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("successfully retrieved")),
            null,
            It.IsAny<Func<It.IsAnyType, Exception, string>>()))
        .Verifiable("Failed to log information correctly");

        // Act
        var result = await _itemService.GetItemAsync(itemId);

        // Assert
        result.Should().NotBeNull();
        result.Should().Be(expectedItem);
        _mockLogger.Verify(); // Verify the information logging
    }

    [Fact]
    public async Task GetItemAsync_ShouldThrowKeyNotFoundException_WhenItemDoesNotExist()
    {
        // Arrange
        int itemId = 10;
        _mockItemRepository.Setup(repo => repo.GetItemByIdAsync(itemId)).ReturnsAsync((Item)null);

        // Setup logger to verify warning logging
        _mockLogger.Setup(x => x.Log(
            LogLevel.Warning,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Item with ID 10 not found")),
            null,
            It.IsAny<Func<It.IsAnyType, Exception, string>>()))
        .Verifiable("Warning about item not found was not logged");

        // Act
        Func<Task> act = async () => await _itemService.GetItemAsync(itemId);

        // Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(act);
        _mockLogger.Verify(); // Verify the warning logging
    }


    [Fact]
    public async Task GetItemAsync_ShouldRethrow_WhenExceptionOccurs()
    {
        // Arrange
        var itemId = 1;
        var exception = new Exception("Database error");
        _mockItemRepository.Setup(repo => repo.GetItemByIdAsync(itemId)).ThrowsAsync(exception);

        // Act & Assert
        var task = _itemService.GetItemAsync(itemId);
        await Assert.ThrowsAsync<Exception>(() => task);
    }

    [Fact]
    public async Task GetItemsAsync_ReturnsItems_WhenItemsExist()
    {
        // Arrange
        var expectedItems = new List<Item>
    {
        new Item { Id = 1, Name = "Item 1" },
        new Item { Id = 2, Name = "Item 2" }
    };
        _mockItemRepository.Setup(repo => repo.GetItemsAsync()).ReturnsAsync(expectedItems);

        // Act
        var items = await _itemService.GetItemsAsync();

        // Assert
        Assert.NotNull(items);
        Assert.Equal(expectedItems.Count, items.Count());
        Assert.Equal(expectedItems, items);
    }

    [Fact]
    public async Task GetItemsAsync_ReturnsEmpty_WhenNoItemsExist()
    {
        // Arrange
        var expectedItems = new List<Item>(); // Empty list
        _mockItemRepository.Setup(repo => repo.GetItemsAsync()).ReturnsAsync(expectedItems);

        // Act
        var items = await _itemService.GetItemsAsync();

        // Assert
        Assert.NotNull(items);
        Assert.Empty(items);
    }

    [Fact]
    public async Task UpdateItemAsync_ShouldUpdateItem_WhenValid()
    {
        // Arrange
        var itemId = 1;
        var existingItem = new Item { Id = itemId, Name = "Old Item" };
        var itemDto = new ItemDto(
        Name: "Updated Item",
        Description: "Description of updated item",
        Quantity: 50,
        Status: null,
        UserId: 1,
        CategoryId: 1
        );
        _mockItemRepository.Setup(repo => repo.GetItemByIdAsync(itemId)).ReturnsAsync(existingItem);
        _mockUserRepository.Setup(repo => repo.IsUserExistAsync(1)).ReturnsAsync(true);
        _mockCategoryRepository.Setup(repo => repo.IsCategoryExistAsync(1)).ReturnsAsync(true);
        _mockMapper.Setup(m => m.Map<ItemDto, Item>(itemDto, existingItem));

        // Act
        await _itemService.UpdateItemAsync(itemId, itemDto);

        // Assert
        _mockItemRepository.Verify(repo => repo.UpdateItemAsync(It.IsAny<Item>()), Times.Once);
    }

    [Fact]
    public async Task UpdateItemAsync_ShouldThrowKeyNotFoundException_WhenItemNotFound()
    {
        // Arrange
        var itemId = 99;
        _mockItemRepository.Setup(repo => repo.GetItemByIdAsync(itemId)).ReturnsAsync((Item)null);

        var itemDto = new ItemDto(
            Name: "Updated Item",
            Description: "Description of updated item",
            Quantity: 50,
            Status: null,
            UserId: 1,
            CategoryId: 1
            );
        // Act & Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(() => _itemService.UpdateItemAsync(itemId, itemDto));
    }

    [Fact]
    public async Task UpdateItemAsync_ShouldThrowKeyNotFoundException_WhenUserNotFound()
    {
        // Arrange
        var itemId = 1;
        var itemDto = new ItemDto(
            Name: "Updated Item",
            Description: "Description of updated item",
            Quantity: 50,
            Status: null,
            UserId: 99,
            CategoryId: 1
            );
        var existingItem = new Item { Id = itemId };
        _mockItemRepository.Setup(repo => repo.GetItemByIdAsync(itemId)).ReturnsAsync(existingItem);
        _mockUserRepository.Setup(repo => repo.IsUserExistAsync(99)).ReturnsAsync(false);

        // Act & Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(() => _itemService.UpdateItemAsync(itemId, itemDto));
    }

    [Fact]
    public async Task UpdateItemAsync_ShouldThrowKeyNotFoundException_WhenCategoryNotFound()
    {
        // Arrange
        var itemId = 1;
        var itemDto = new ItemDto(
            Name: "Updated Item",
            Description: "Description of updated item",
            Quantity: 50,
            Status: null,
            UserId: 1,
            CategoryId: 999
            );
        var existingItem = new Item { Id = itemId };
        _mockItemRepository.Setup(repo => repo.GetItemByIdAsync(itemId)).ReturnsAsync(existingItem);
        _mockCategoryRepository.Setup(repo => repo.IsCategoryExistAsync(99)).ReturnsAsync(false);

        // Act & Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(() => _itemService.UpdateItemAsync(itemId, itemDto));
    }

    [Fact]
    public async Task DeleteItemAsync_ShouldDeleteItem_WhenItemExists()
    {
        // Arrange
        var itemId = 1;
        var item = new Item { Id = itemId, Name = "Test Item" };
        _mockItemRepository.Setup(repo => repo.GetItemByIdAsync(itemId)).ReturnsAsync(item);

        // Act
        await _itemService.DeleteItemAsync(itemId);

        // Assert
        _mockItemRepository.Verify(repo => repo.DeleteItemAsync(item), Times.Once);
    }


    [Fact]
    public async Task DeleteItemAsync_ShouldThrowKeyNotFoundException_WhenItemDoesNotExist()
    {
        // Arrange
        var itemId = 99;
        _mockItemRepository.Setup(repo => repo.GetItemByIdAsync(itemId)).ReturnsAsync((Item)null);

        // Act & Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(() => _itemService.DeleteItemAsync(itemId));
    }


    [Fact]
    public async Task DeleteItemAsync_ShouldRethrow_WhenUnexpectedExceptionOccurs()
    {
        // Arrange
        var itemId = 1;
        var item = new Item { Id = itemId, Name = "Test Item" };
        _mockItemRepository.Setup(repo => repo.GetItemByIdAsync(itemId)).ReturnsAsync(item);
        _mockItemRepository.Setup(repo => repo.DeleteItemAsync(item)).ThrowsAsync(new Exception("Database error"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _itemService.DeleteItemAsync(itemId));
    }

    [Theory]
    [InlineData(-1, ItemStatus.OutOfStock)]
    [InlineData(0, ItemStatus.OutOfStock)]
    [InlineData(1, ItemStatus.LowStock)]
    [InlineData(20, ItemStatus.LowStock)]
    [InlineData(21, ItemStatus.InStock)]
    public void UpdateItemStatus_SetsCorrectStatus(int quantity, ItemStatus expectedStatus)
    {
        // Arrange
        var item = new Item { Quantity = quantity };

        // Act
        _itemService.UpdateItemStatus(item);

        // Assert
        item.Status.Should().Be(expectedStatus,
            because: $"items with quantity {quantity} should be {expectedStatus}");
    }
}
