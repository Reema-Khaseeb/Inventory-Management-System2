using AutoMapper;
using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Dtos;
using InventoryManagementSystem.Dtos.Error;
using InventoryManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InventoryManagementSystem.Api.Controllers;

[Route("api/v1/categories")]
[Authorize]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new category.
    /// </summary>
    /// <param name="categoryDto">The details of the new category to create.</param>
    /// <response code="201">Returns the newly created category</response>
    /// <response code="400">If the category is null or validation fails</response>
    /// <response code="500">If an unexpected error occurs</response>
    /// <returns>A newly created category object.</returns>
    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created, "Successfully created category", typeof(CategoryDto))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request data", typeof(ErrorResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "An internal server error occurred.", typeof(ErrorResponse))]
    public async Task<ActionResult<CategoryDto>> CreateCategory([FromBody] CategoryDto categoryDto)
    {
        try
        {
            var category = _mapper.Map<Category>(categoryDto);
            var createdCategory = await _categoryService.CreateCategoryAsync(category);
            var createdCategoryDto = _mapper.Map<CategoryDto>(createdCategory);

            return CreatedAtAction(nameof(GetCategory),
                new { id = createdCategory.Id }, createdCategoryDto);
        }
        catch (ArgumentException argEx)
        {
            return BadRequest(new ErrorResponse("Bad Request", argEx.Message));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ErrorResponse("Internal Server Error", ex.Message));
        }
    }

    /// <summary>
    /// Retrieves a single category by its ID.
    /// </summary>
    /// <param name="id">The ID of the category to retrieve.</param>
    /// <response code="200">Returns the category with the specified ID</response>
    /// <response code="404">If the category with the specified ID is not found</response>
    /// <response code="500">If an unexpected error occurs</response>
    /// <returns>The requested category if found, otherwise returns a NotFound or BadRequest result.</returns>
    [HttpGet("{id}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved category", typeof(CategoryDto))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Category not found", typeof(ErrorResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
    public async Task<ActionResult<CategoryDto>> GetCategory(int id)
    {
        try
        {
            var category = await _categoryService.GetCategoryAsync(id);
            return Ok(category);
        }
        catch (KeyNotFoundException knfEx)
        {
            return NotFound(new ErrorResponse("Not Found", knfEx.Message));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ErrorResponse("Internal Server Error", ex.Message));
        }
    }

    /// <summary>
    /// Retrieves all categories.
    /// </summary>
    /// <response code="200">Returns all categories</response>
    /// <returns>A collection of all category objects.</returns>
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved all categories", typeof(IEnumerable<CategoryDto>))]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
    {
        try
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return Ok(categories);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ErrorResponse("Internal Server Error", ex.Message));
        }
    }

    /// <summary>
    /// Updates a category based on provided data.
    /// </summary>
    /// <param name="id">The ID of the category to update.</param>
    /// <param name="categoryDto">The data transfer object containing update data.</param>
    /// <response code="204">Indicates the category was successfully updated.</response>
    /// <response code="400">If the provided data is invalid.</response>
    /// <response code="404">If the category does not exist.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    /// <returns>A result indicating the outcome of the operation.</returns>
    [HttpPut("{id}")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Successfully updated the category")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid data provided", typeof(ErrorResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Category not found", typeof(ErrorResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDto categoryDto)
    {
        try
        {
            await _categoryService.UpdateCategoryAsync(id, categoryDto);
            return NoContent();
        }
        catch (KeyNotFoundException knfEx)
        {
            return NotFound(new ErrorResponse("Not Found", knfEx.Message));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ErrorResponse("Internal Server Error", ex.Message));
        }
    }

    /// <summary>
    /// Deletes a category by its ID.
    /// </summary>
    /// <param name="id">The ID of the category to delete.</param>
    /// <response code="204">Indicates the category was successfully deleted.</response>
    /// <response code="404">If the category is not found.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    /// <returns>A result indicating the outcome of the operation.</returns>
    [HttpDelete("{id}")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Successfully deleted the category")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Category not found", typeof(ErrorResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        try
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException knfEx)
        {
            return NotFound(new ErrorResponse("Not Found", knfEx.Message));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ErrorResponse("Internal Server Error", ex.Message));
        }
    }
}
