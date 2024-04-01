namespace InventoryManagementSystem.Dtos.User;
public record UserRequest(
    string Username,
    string Password,
    string Email);
