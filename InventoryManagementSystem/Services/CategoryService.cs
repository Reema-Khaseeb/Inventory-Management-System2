using AutoMapper;
using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Db.Repositories.Interfaces;
using InventoryManagementSystem.Dtos;
using InventoryManagementSystem.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace InventoryManagementSystem.Services;
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ILogger<ItemService> _logger;
    private readonly IMapper _mapper;

    public CategoryService(
        ICategoryRepository categoryRepository,
        ILogger<ItemService> logger,
        IMapper mapper
        )
    {
        _categoryRepository = categoryRepository;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new category asynchronously.
    /// </summary>
    /// <param name="categoryDto">The DTO of the category to create.</param>
    /// <returns>The created category.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the new category argument is null.</exception>
    public async Task<Category> CreateCategoryAsync(Category category)
    {
        ArgumentNullException.ThrowIfNull(category, nameof(category));

        try
        {
            var createdCategory = await _categoryRepository.CreateCategoryAsync(category);
            _logger.LogInformation($"Category {createdCategory.Id} created successfully.");
            return createdCategory;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while creating a new category.");
            throw;
        }
    }

    /// <summary>
    /// Retrieves a single category by its ID.
    /// </summary>
    /// <param name="id">The ID of the category to retrieve.</param>
    /// <returns>The requested category if found.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the category is not found.</exception>
    public async Task<Category> GetCategoryAsync(int id)
    {
        try
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                _logger.LogWarning($"Category with ID {id} not found.");
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }

            _logger.LogInformation($"Category with ID {id} successfully retrieved.");
            return category;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while attempting to retrieve category with ID {id}.");
            throw;
        }
    }

    /// <summary>
    /// Retrieves all categories.
    /// </summary>
    /// <returns>A collection of all categories.</returns>
    public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
    {
        var categories = await _categoryRepository.GetCategoriesAsync();
        _logger.LogInformation("All categories successfully retrieved.");
        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    /// <summary>
    /// Updates a category based on provided data.
    /// </summary>
    /// <param name="id">The ID of the category to update.</param>
    /// <param name="categoryDto">The data transfer object containing update data.</param>
    /// <exception cref="KeyNotFoundException">Thrown if the item does not exist.</exception>
    public async Task UpdateCategoryAsync(int id, CategoryDto categoryDto)
    {
        try
        {
            var existingCategory = await GetCategoryAsync(id);
            _mapper.Map(categoryDto, existingCategory);

            await _categoryRepository.UpdateCategoryAsync(existingCategory);
            _logger.LogInformation($"Category with ID: {id} has been successfully updated.");
        }
        catch (KeyNotFoundException knfEx)
        {
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An unexpected error occurred" +
                $"while attempting to update the category with ID: {id}.");
            throw;
        }
    }

    /// <summary>
    /// Deletes a category by its ID.
    /// </summary>
    /// <param name="id">The ID of the category to delete.</param>
    public async Task DeleteCategoryAsync(int id)
    {
        try
        {
            var category = await GetCategoryAsync(id);

            await _categoryRepository.DeleteCategoryAsync(category);
            _logger.LogInformation($"Category with ID: {id} has been successfully deleted.");
        }
        catch (KeyNotFoundException knfEx)
        {
            _logger.LogError(knfEx, $"Failed to delete category because it was not found: {knfEx.Message}");
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An unexpected error occurred while attempting to delete the category with ID: {id}");
            throw;
        }
    }
}
