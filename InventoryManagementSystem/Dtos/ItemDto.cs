using InventoryManagementSystem.Common.Enums;

namespace InventoryManagementSystem.Dtos;
public record ItemDto(
    string? Name,
    string? Description,
    int? Quantity,
    ItemStatus? Status,
    int? UserId,
    int? CategoryId
    );
