using InventoryManagementSystem.Dtos.Login;

namespace InventoryManagementSystem.Services.Interfaces;
public interface IAuthenticationService
{
    Task<string> LoginAsync(LoginRequest loginRequest);
}