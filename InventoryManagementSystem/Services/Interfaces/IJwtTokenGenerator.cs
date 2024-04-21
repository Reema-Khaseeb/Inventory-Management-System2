using InventoryManagementSystem.Db.Models;

namespace InventoryManagementSystem.Services.Interfaces;
public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
    bool ValidateToken(string token);
}