using InventoryManagementSystem.Db;
using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Db.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using InventoryManagementSystem.Db.Repositories.Interfaces;

namespace InventoryManagementSystem.Tests.CategoryTests;

public class CategoryRepositoryTests
{
    private readonly InventoryManagementSystemDbContext _dbContext;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<InventoryManagementSystemDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _dbContext = new InventoryManagementSystemDbContext(options);
        _categoryRepository = new CategoryRepository(_dbContext);

        InitializeTestData();
    }

    private void InitializeTestData()
    {
        _dbContext.Categories.AddRange(
            new Category { Name = "Electronics" },
            new Category { Name = "Books" }
        );
        _dbContext.SaveChanges();
    }

    [Fact]
    public async Task CreateCategoryAsync_ShouldAddCategory()
    {
        // Arrange
        var newCategory = new Category { Name = "Clothing" };

        // Act
        var createdCategory = await _categoryRepository.CreateCategoryAsync(newCategory);

        // Assert
        createdCategory.Should().NotBeNull();
        _dbContext.Categories.Should().ContainEquivalentOf(createdCategory);
    }

    [Fact]
    public async Task UpdateCategoryAsync_ShouldUpdateCategory()
    {
        // Arrange
        var category = await _dbContext.Categories.FirstAsync();
        category.Name = "Updated Electronics";

        // Act
        await _categoryRepository.UpdateCategoryAsync(category);

        // Assert
        var updatedCategory = await _categoryRepository.GetCategoryByIdAsync(category.Id);
        updatedCategory.Name.Should().Be("Updated Electronics");
    }

    [Fact]
    public async Task DeleteCategoryAsync_ShouldRemoveCategory()
    {
        // Arrange
        var category = await _dbContext.Categories.FirstAsync();

        // Act
        await _categoryRepository.DeleteCategoryAsync(category);

        // Assert
        _dbContext.Categories.Should().NotContain(category);
    }

    [Fact]
    public async Task GetCategoryByIdAsync_ShouldReturnCategory()
    {
        // Arrange
        var expectedCategory = await _dbContext.Categories.FirstAsync();

        // Act
        var category = await _categoryRepository.GetCategoryByIdAsync(expectedCategory.Id);

        // Assert
        category.Should().BeEquivalentTo(expectedCategory);
    }

    [Fact]
    public async Task GetCategoriesAsync_ShouldReturnAllCategories()
    {
        // Act
        var categories = await _categoryRepository.GetCategoriesAsync();

        // Assert
        categories.Should().NotBeNull();
    }

    [Theory]
    [InlineData(1, true)]
    [InlineData(100, false)]
    public async Task IsCategoryExistAsync_ShouldReturnCorrectResult(int categoryId, bool expected)
    {
        // Act
        var doesExist = await _categoryRepository.IsCategoryExistAsync(categoryId);

        // Assert
        doesExist.Should().Be(expected);
    }
}

