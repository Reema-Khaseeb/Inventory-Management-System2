using Moq;
using InventoryManagementSystem.Services;
using InventoryManagementSystem.Db.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using AutoMapper;
using InventoryManagementSystem.Db.Models;
using FluentAssertions;
using InventoryManagementSystem.Dtos;

namespace InventoryManagementSystem.Tests.CategoryTests;

public class CategoryServiceTests
{
    private readonly Mock<ICategoryRepository> _mockCategoryRepository;
    private readonly Mock<ILogger<CategoryService>> _mockLogger;
    private readonly Mock<IMapper> _mockMapper;
    private readonly CategoryService _categoryService;

    public CategoryServiceTests()
    {
        _mockCategoryRepository = new Mock<ICategoryRepository>();
        _mockLogger = new Mock<ILogger<CategoryService>>();
        _mockMapper = new Mock<IMapper>();
        _categoryService = new CategoryService(_mockCategoryRepository.Object, _mockLogger.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task CreateCategoryAsync_ShouldCreateCategory_WhenValidInput()
    {
        // Arrange
        var category = new Category { Name = "Electronics" };
        _mockCategoryRepository.Setup(repo => repo.CreateCategoryAsync(It.IsAny<Category>())).ReturnsAsync(category);

        // Act
        var result = await _categoryService.CreateCategoryAsync(category);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(category);
        _mockCategoryRepository.Verify(repo => repo.CreateCategoryAsync(category), Times.Once);
    }

    [Fact]
    public async Task CreateCategoryAsync_ShouldThrowArgumentNullException_WhenCategoryIsNull()
    {
        // Act
        Func<Task> act = async () => await _categoryService.CreateCategoryAsync(null);

        // Assert
        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task CreateCategoryAsync_ShouldHandleExceptionProperly()
    {
        // Arrange
        var category = new Category { Name = "Electronics" };
        _mockCategoryRepository.Setup(repo => repo.CreateCategoryAsync(It.IsAny<Category>())).ThrowsAsync(new Exception("Database failure"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _categoryService.CreateCategoryAsync(category));
    }

    [Fact]
    public async Task GetCategoryAsync_ShouldReturnCategory_WhenCategoryExists()
    {
        // Arrange
        var expectedCategory = new Category { Id = 1, Name = "Electronics" };
        _mockCategoryRepository.Setup(repo => repo.GetCategoryByIdAsync(expectedCategory.Id)).ReturnsAsync(expectedCategory);

        // Act
        var result = await _categoryService.GetCategoryAsync(expectedCategory.Id);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedCategory);
    }

    [Fact]
    public async Task GetCategoryAsync_ShouldThrowKeyNotFoundException_WhenCategoryDoesNotExist()
    {
        // Arrange
        var categoryId = 2;
        _mockCategoryRepository.Setup(repo => repo.GetCategoryByIdAsync(categoryId)).ReturnsAsync((Category)null);

        // Act
        Func<Task> act = async () => await _categoryService.GetCategoryAsync(categoryId);

        // Assert
        await act.Should().ThrowAsync<KeyNotFoundException>()
            .WithMessage($"Category with ID {categoryId} not found.");
    }

    [Fact]
    public async Task GetCategoriesAsync_ShouldReturnAllCategories()
    {
        // Arrange
        var categories = new List<Category>
        {
        new Category { Id = 1, Name = "Electronics" },
        new Category { Id = 2, Name = "Books" }
        };
        var categoryDtos = categories.Select(category => new CategoryDto(category.Name)).ToList();

        _mockCategoryRepository.Setup(repo => repo.GetCategoriesAsync()).ReturnsAsync(categories);
        _mockMapper.Setup(mapper => mapper.Map<IEnumerable<CategoryDto>>(It.IsAny<IEnumerable<Category>>()))
                   .Returns(categoryDtos);

        // Act
        var result = await _categoryService.GetCategoriesAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(categoryDtos);
        _mockCategoryRepository.Verify(repo => repo.GetCategoriesAsync(), Times.Once);
        _mockMapper.Verify(mapper => mapper.Map<IEnumerable<CategoryDto>>(categories), Times.Once);
    }

    [Fact]
    public async Task UpdateCategoryAsync_ShouldUpdateCategory_WhenCategoryExists()
    {
        // Arrange
        var categoryId = 1;
        var categoryToUpdate = new Category { Id = categoryId, Name = "Original" };
        var categoryDto = new CategoryDto("Updated");

        _mockCategoryRepository.Setup(repo => repo.GetCategoryByIdAsync(categoryId))
                               .ReturnsAsync(categoryToUpdate);
        _mockCategoryRepository.Setup(repo => repo.UpdateCategoryAsync(It.IsAny<Category>()))
                               .Returns(Task.CompletedTask);
        _mockMapper.Setup(mapper => mapper.Map(It.IsAny<CategoryDto>(), It.IsAny<Category>()))
                   .Callback<CategoryDto, Category>((dto, category) => category.Name = dto.Name);

        // Act
        await _categoryService.UpdateCategoryAsync(categoryId, categoryDto);

        // Assert
        categoryToUpdate.Name.Should().Be(categoryDto.Name);
        _mockCategoryRepository.Verify(repo => repo.UpdateCategoryAsync(categoryToUpdate), Times.Once);
    }

    [Fact]
    public async Task UpdateCategoryAsync_ShouldUpdateCategory_WhenValidInput()
    {
        // Arrange
        var categoryDto = new CategoryDto("Updated");
        var existingCategory = new Category { Id = 1, Name = "Original" };
        _mockCategoryRepository.Setup(repo => repo.GetCategoryByIdAsync(1))
                               .ReturnsAsync(existingCategory);
        _mockCategoryRepository.Setup(repo => repo.UpdateCategoryAsync(It.IsAny<Category>()))
                               .Returns(Task.CompletedTask);

        // Act
        await _categoryService.UpdateCategoryAsync(1, categoryDto);

        // Assert
        _mockMapper.Verify(m => m.Map(categoryDto, existingCategory), Times.Once);
        _mockCategoryRepository.Verify(repo => repo.UpdateCategoryAsync(existingCategory), Times.Once);
    }

    [Fact]
    public async Task UpdateCategoryAsync_ShouldThrowArgumentNullException_WhenCategoryDtoIsNull()
    {
        // Act & Assert
        Func<Task> act = async () => await _categoryService.UpdateCategoryAsync(1, null);

        // Assert
        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task UpdateCategoryAsync_ShouldThrowKeyNotFoundException_WhenCategoryDoesNotExist()
    {
        // Arrange
        var categoryDto = new CategoryDto("Updated");
        _mockCategoryRepository.Setup(repo => repo.GetCategoryByIdAsync(1))
                               .ReturnsAsync((Category)null);

        // Act & Assert
        Func<Task> act = async () => await _categoryService.UpdateCategoryAsync(1, categoryDto);

        // Assert
        await act.Should().ThrowAsync<KeyNotFoundException>();
    }

    [Fact]
    public async Task UpdateCategoryAsync_ShouldHandleExceptionsProperly()
    {
        // Arrange
        var categoryDto = new CategoryDto("Updated");
        var existingCategory = new Category { Id = 1, Name = "Original" };
        _mockCategoryRepository.Setup(repo => repo.GetCategoryByIdAsync(1))
                               .ReturnsAsync(existingCategory);
        _mockCategoryRepository.Setup(repo => repo.UpdateCategoryAsync(It.IsAny<Category>()))
                               .ThrowsAsync(new Exception("Database error"));

        // Act & Assert
        Func<Task> act = async () => await _categoryService.UpdateCategoryAsync(1, categoryDto);

        // Assert
        await act.Should().ThrowAsync<Exception>()
            .WithMessage("Database error");
    }

    [Fact]
    public async Task DeleteCategoryAsync_ShouldThrowKeyNotFoundException_WhenCategoryDoesNotExist()
    {
        // Arrange
        var categoryId = 2;
        _mockCategoryRepository.Setup(repo => repo.GetCategoryByIdAsync(categoryId)).ReturnsAsync((Category)null);

        _mockLogger.Setup(
            x => x.Log(
                LogLevel.Error, // Check that the log level is Error
                It.IsAny<EventId>(), // Ignore the event ID
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("not found")), // Check the log contains "not found"
                It.IsAny<Exception>(), // Check that any exception is logged
                It.IsAny<Func<It.IsAnyType, Exception, string>>())) // Ignore how the message is formatted
            .Verifiable();

        // Act & Assert
        Func<Task> act = async () => await _categoryService.DeleteCategoryAsync(categoryId);

        // Assert
        await act.Should().ThrowAsync<KeyNotFoundException>();
        _mockLogger.Verify(); // This will throw if the log was not as expected
    }

    [Fact]
    public async Task DeleteCategoryAsync_ShouldHandleExceptionsProperly()
    {
        // Arrange
        var categoryId = 1;
        var category = new Category { Id = categoryId, Name = "Electronics" };
        _mockCategoryRepository.Setup(repo => repo.GetCategoryByIdAsync(categoryId)).ReturnsAsync(category);
        _mockCategoryRepository.Setup(repo => repo.DeleteCategoryAsync(category)).ThrowsAsync(new Exception("Database error"));

        // Setup logger to capture and verify error logs correctly
        _mockLogger.Setup(
            x => x.Log(
                LogLevel.Error, // Ensure that only log entries with LogLevel.Error are matched by this setup.
                It.IsAny<EventId>(), // Accept any EventId, which means the specific EventId does not matter for this test case.
                It.Is<It.IsAnyType>((v, t) => true), //  accept any log message
                It.IsAny<Exception>(), // Accept any exception.
                It.IsAny<Func<It.IsAnyType, Exception, string>>()))  // Ignore how the message is formatted
                .Verifiable("Logging of an exception failed."); // Mark this setup as verifiable with a custom failure message if the setup is not met

        // Act
        Func<Task> act = async () => await _categoryService.DeleteCategoryAsync(categoryId);

        // Assert
        await act.Should().ThrowAsync<Exception>().WithMessage("Database error");
        _mockLogger.Verify(); // Ensure the logging was performed as expected.
    }

    [Fact]
    public async Task DeleteCategoryAsync_ShouldDeleteCategory_WhenCategoryExists()
    {
        // Arrange
        var categoryId = 1;
        var category = new Category { Id = categoryId, Name = "Electronics" };
        _mockCategoryRepository.Setup(repo => repo.GetCategoryByIdAsync(categoryId)).ReturnsAsync(category);
        _mockCategoryRepository.Setup(repo => repo.DeleteCategoryAsync(category)).Returns(Task.CompletedTask);

        // Set up the mock behavior for the Log method on the ILogger object.
        _mockLogger.Setup(
            // Define the method signature that should be mocked.
            x => x.Log(
                LogLevel.Information, // Match any log entries made at the Information level.
                It.IsAny<EventId>(), // Accept any EventId (ignore the value).
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("successfully deleted")), // Match if the log message contains "successfully deleted".
                null, // Expect the exception parameter to be null, indicating no exception should be part of this log entry.
                It.IsAny<Func<It.IsAnyType, Exception, string>>())) // Accept any formatter used for creating the log message string.
            .Verifiable("Logging failure."); // Mark this setup as verifiable, with a custom message if verification fails.

        // Act
        await _categoryService.DeleteCategoryAsync(categoryId);

        // Assert
        _mockCategoryRepository.Verify(repo => repo.DeleteCategoryAsync(category), Times.Once);
        _mockLogger.Verify();
    }
}
