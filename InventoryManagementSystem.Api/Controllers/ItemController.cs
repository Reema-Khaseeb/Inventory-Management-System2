using AutoMapper;
using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Dtos;
using InventoryManagementSystem.Dtos.Error;
using InventoryManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InventoryManagementSystem.Api.Controllers;
[Route("api/v1/items")]
[Authorize]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;
    private readonly IMapper _mapper;

    public ItemController(IItemService itemService, IMapper mapper)
    {
        _itemService = itemService;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new inventory item.
    /// </summary>
    /// <param name="newItem">The details of the new item to create.</param>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null or validation fails</response>
    /// <response code="404">If specified category or user doesn't exist</response>
    /// <response code="500">If an unexpected error occurs</response>
    /// <returns>A newly created inventory item object.</returns>
    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created,
            "Successfully created item", typeof(ItemDto))]
    [SwaggerResponse(StatusCodes.Status404NotFound,
            "Category or User not found", typeof(ErrorResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest,
            "Invalid request data", typeof(FluentValidation.Results.ValidationResult))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError,
            "An internal server error occurred.", typeof(ErrorResponse))]
    public async Task<ActionResult<ItemDto>> CreateItem([FromBody] ItemDto itemDto)
    {
        try
        {
            var item = _mapper.Map<Item>(itemDto);
            var createdItem = await _itemService.CreateItemAsync(item);
            var createdItemDto = _mapper.Map<ItemDto>(createdItem);

            return CreatedAtAction(nameof(GetItem),
                new { id = createdItem.Id }, createdItemDto);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new ErrorResponse("Not Found", ex.Message));
        }
        catch (ArgumentException argEx)
        {
            return BadRequest(new ErrorResponse("Bad Request", argEx.Message));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                new ErrorResponse("Internal Server Error",
                ex.Message));
        }
    }

    /// <summary>
    /// Retrieves a single item by its ID.
    /// </summary>
    /// <param name="id">The ID of the item to retrieve.</param>
    /// <response code="200">Returns the item with the specified ID</response>
    /// <response code="404">If the item with the specified ID is not found</response>
    /// <response code="500">If an unexpected error occurs</response>
    /// <returns>The requested item if found, otherwise returns a NotFound or BadRequest result.</returns>
    [HttpGet("{id}")]
    [SwaggerResponse(StatusCodes.Status200OK,
            "Successfully retrieved item", typeof(ItemDto))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Item not found", typeof(ErrorResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
    public async Task<ActionResult<ItemDto>> GetItem(int id)
    {
        try
        {
            var item = await _itemService.GetItemAsync(id);
            var itemDto = _mapper.Map<ItemDto>(item);
            return Ok(itemDto);
        }
        catch (KeyNotFoundException knfEx)
        {
            return NotFound(new ErrorResponse("Not Found", knfEx.Message));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                new ErrorResponse("Internal Server Error",
                "An unexpected error occurred. Please try again later."));
        }
    }

    /// <summary>
    /// Retrieves all items.
    /// </summary>
    /// <returns>A collection of all items.</returns>
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK,
            "Successfully retrieved items", typeof(IEnumerable<ItemDto>))]
    public async Task<ActionResult<IEnumerable<ItemDto>>> GetItems()
    {
        try
        {
            var items = await _itemService.GetItemsAsync();
            var itemDtos = _mapper.Map<IEnumerable<ItemDto>>(items);
            return Ok(itemDtos);
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                new ErrorResponse("Internal Server Error",
                "An error occurred while retrieving all items."));
        }
    }

    /// <summary>
    /// Updates an item based on provided data.
    /// </summary>
    /// <param name="id">The ID of the item to update.</param>
    /// <param name="itemDto">The data transfer object containing update data.</param>
    /// <response code="204">Indicates the item was successfully updated.</response>
    /// <response code="400">If the provided data is invalid.</response>
    /// <response code="404">If the item, specified user, or category does not exist.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    /// <returns>A result indicating the outcome of the operation.</returns>
    [HttpPut("{id:int}")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Successfully updated the item")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Validation error",
            typeof(FluentValidation.Results.ValidationResult))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Item, user, or category not found", typeof(ErrorResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
    public async Task<IActionResult> UpdateItem(int id, [FromBody] ItemDto itemDto)
    {
        try
        {
            await _itemService.UpdateItemAsync(id, itemDto);
            return NoContent();
        }
        catch (KeyNotFoundException knfEx)
        {
            return NotFound(new ErrorResponse("Not Found", knfEx.Message));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                new ErrorResponse("Internal Server Error",
                "An unexpected error occurred. Please try again later."));
        }
    }

    /// <summary>
    /// Deletes an item by its ID.
    /// </summary>
    /// <param name="id">The ID of the item to delete.</param>
    /// <returns>A result indicating the outcome of the operation.</returns>
    [HttpDelete("{id:int}")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Successfully deleted the item")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Item not found", typeof(ErrorResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
    public async Task<IActionResult> DeleteItem(int id)
    {
        try
        {
            await _itemService.DeleteItemAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException knfEx)
        {
            return NotFound(new ErrorResponse("Not Found", knfEx.Message));
        }
        catch (Exception ex)
        {
            return StatusCode(500,
                new ErrorResponse("Internal Server Error",
                "An unexpected error occurred. Please try again later."));
        }
    }

}
