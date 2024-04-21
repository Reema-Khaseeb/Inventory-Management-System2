using InventoryManagementSystem.Common.Enums;
using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Db.Repositories.Interfaces;
using InventoryManagementSystem.Db.Repositories;
using InventoryManagementSystem.Db;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;

namespace InventoryManagementSystem.Tests.ItemTests;

public class ItemRepositoryTests
{
    private readonly InventoryManagementSystemDbContext _dbContext;
    private readonly IItemRepository _itemRepository;

    public ItemRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<InventoryManagementSystemDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _dbContext = new InventoryManagementSystemDbContext(options);
        _itemRepository = new ItemRepository(_dbContext);

        InitializeTestData();
    }

    private void InitializeTestData()
    {
        var user = new User { Username = "user1", Email = "user1@example.com", Password = "Password1" };
        var category = new Category { Name = "Electronics" };

        _dbContext.Users.Add(user);
        _dbContext.Categories.Add(category);
        _dbContext.Items.AddRange(
            new Item { Name = "Laptop", Description = "High-end laptop", Quantity = 10, Status = ItemStatus.LowStock, User = user, Category = category },
            new Item { Name = "Mobile", Description = "mobile", Quantity = 10, Status = ItemStatus.LowStock, User = user, Category = category }
            );
        _dbContext.SaveChanges();
    }

    [Fact]
    public async Task CreateItemAsync_ShouldAddItem()
    {
        // Arrange
        var newItem = new Item { Name = "Camera", Description = "DSLR Camera", Quantity = 40, Status = ItemStatus.InStock, UserId = 1, CategoryId = 1 };

        // Act
        var createdItem = await _itemRepository.CreateItemAsync(newItem);

        // Assert
        createdItem.Should().NotBeNull();
        _dbContext.Items.Should().ContainEquivalentOf(createdItem);
    }

    [Fact]
    public async Task UpdateItemAsync_ShouldUpdateItem()
    {
        // Arrange
        var item = await _dbContext.Items.FirstAsync();
        item.Name = "Updated Laptop";

        // Act
        await _itemRepository.UpdateItemAsync(item);

        // Assert
        var updatedItem = await _itemRepository.GetItemByIdAsync(item.Id);
        updatedItem.Name.Should().Be("Updated Laptop");
    }

    [Fact]
    public async Task GetItemByIdAsync_ShouldReturnItem()
    {
        // Arrange
        var expectedItem = await _dbContext.Items.FirstAsync();

        // Act
        var item = await _itemRepository.GetItemByIdAsync(expectedItem.Id);

        // Assert
        item.Should().BeEquivalentTo(expectedItem);
    }

    [Fact]
    public async Task GetItemsAsync_ShouldReturnAllItems()
    {
        // Act
        var items = await _itemRepository.GetItemsAsync();

        // Assert
        items.Should().NotBeNull();
    }

    [Fact]
    public async Task DeleteItemAsync_ShouldRemoveItem()
    {
        // Arrange
        var item = await _dbContext.Items.FirstAsync();

        // Act
        await _itemRepository.DeleteItemAsync(item);

        // Assert
        _dbContext.Items.Should().NotContain(item);
    }

}
