using InventoryManagementSystem.Db.Models;

namespace InventoryManagementSystem.Db.Utilities;
public static class SeedData
{
    public static List<User> SeedUsers()
    {
        var users = new List<User>();
        for (int i = 3; i <= 50; i++)
        {
            users.Add(new User
            {
                UserId = i,
                Username = $"user{i}",
                Password = HashPassword($"password{i}"),
                Email = $"user{i}@example.com"
            });
        }
        return users;
    }

    private static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}
