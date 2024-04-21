using InventoryManagementSystem.Dtos;
using InventoryManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Api.Controllers;

[ApiController]
[Route("api/search")]
[Authorize]
public class SearchController : ControllerBase
{
    private readonly IItemSearchService _itemSearchService;

    public SearchController(IItemSearchService itemSearchService)
    {
        _itemSearchService = itemSearchService;
    }

    /// <summary>
    /// Searches items based on various criteria.
    /// </summary>
    /// <param name="criteria">The search criteria.</param>
    /// <returns>A collection of items that match the search criteria.</returns>
    [HttpPost("items")]
    public async Task<ActionResult<IEnumerable<ItemDto>>> SearchItems([FromBody] ItemSearchCriteriaDto criteria)
    {
        var items = await _itemSearchService.SearchItemsAsync(criteria);
        return Ok(items);
    }
}
