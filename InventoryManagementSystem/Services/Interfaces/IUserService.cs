using InventoryManagementSystem.Dtos.User;

namespace InventoryManagementSystem.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> IsEmailUniqueAsync(string email);
        Task<bool> IsUsernameUniqueAsync(string username);
        Task<UserResponse> RegisterUserAsync(UserRequest userRequest);
    }
}