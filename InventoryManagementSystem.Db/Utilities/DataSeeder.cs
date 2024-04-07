using InventoryManagementSystem.Common.Enums;
using InventoryManagementSystem.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Db.Utilities;
public static class DataSeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        SeedUsers(modelBuilder);
        SeedCategories(modelBuilder);
        SeedItems(modelBuilder);
    }

    private static void SeedItems(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasData(
            new Item { Id = 1, Name = "Laptop", Description = "A portable computer", Quantity = 10, Status = ItemStatus.LowStock, CategoryId = 1, UserId = 1 },
        new Item { Id = 2, Name = "T-Shirt", Description = "A cotton shirt", Quantity = 50, Status = ItemStatus.InStock, CategoryId = 2, UserId = 2 },
        new Item { Id = 3, Name = "Smartphone", Description = "High-end mobile phone", Quantity = 25, Status = ItemStatus.InStock, CategoryId = 1, UserId = 3 },
        new Item { Id = 4, Name = "Jeans", Description = "Denim jeans", Quantity = 0, Status = ItemStatus.OutOfStock, CategoryId = 2, UserId = 4 },
        new Item { Id = 5, Name = "E-Reader", Description = "Electronic book reader", Quantity = 15, Status = ItemStatus.LowStock, CategoryId = 3, UserId = 5 },
        new Item { Id = 6, Name = "Blender", Description = "Kitchen appliance", Quantity = 20, Status = ItemStatus.InStock, CategoryId = 4, UserId = 6 },
        new Item { Id = 7, Name = "Microwave Oven", Description = "Heats food quickly and efficiently", Quantity = 30, Status = ItemStatus.InStock, CategoryId = 4, UserId = 7 },
        new Item { Id = 8, Name = "Fantasy Novel", Description = "A novel set in a fictional universe", Quantity = 50, Status = ItemStatus.InStock, CategoryId = 3, UserId = 8 },
        new Item { Id = 9, Name = "Headphones", Description = "Wireless over-ear headphones", Quantity = 60, Status = ItemStatus.InStock, CategoryId = 1, UserId = 9 },
        new Item { Id = 10, Name = "Sweater", Description = "Warm wool sweater", Quantity = 35, Status = ItemStatus.InStock, CategoryId = 2, UserId = 10 },
        new Item { Id = 11, Name = "Lamp", Description = "LED desk lamp", Quantity = 40, Status = ItemStatus.InStock, CategoryId = 4, UserId = 11 },
        new Item { Id = 12, Name = "History Book", Description = "Covers world history", Quantity = 20, Status = ItemStatus.InStock, CategoryId = 3, UserId = 12 },
        new Item { Id = 13, Name = "Gaming Console", Description = "Latest generation home video game console", Quantity = 15, Status = ItemStatus.LowStock, CategoryId = 1, UserId = 13 },
        new Item { Id = 14, Name = "Running Shoes", Description = "Lightweight and comfortable running shoes", Quantity = 25, Status = ItemStatus.InStock, CategoryId = 2, UserId = 14 },
        new Item { Id = 15, Name = "Sci-Fi Novel", Description = "Space adventure novel", Quantity = 30, Status = ItemStatus.InStock, CategoryId = 3, UserId = 15 },
        new Item { Id = 16, Name = "Coffee Maker", Description = "Automatic drip coffee maker", Quantity = 20, Status = ItemStatus.InStock, CategoryId = 4, UserId = 16 },
        new Item { Id = 17, Name = "Smartwatch", Description = "Wearable technology for fitness tracking", Quantity = 40, Status = ItemStatus.InStock, CategoryId = 1, UserId = 17 },
        new Item { Id = 18, Name = "Leather Jacket", Description = "High-quality leather jacket", Quantity = 10, Status = ItemStatus.LowStock, CategoryId = 2, UserId = 18 },
        new Item { Id = 19, Name = "Cookbook", Description = "Collection of gourmet recipes", Quantity = 50, Status = ItemStatus.InStock, CategoryId = 3, UserId = 19 },
        new Item { Id = 20, Name = "Air Purifier", Description = "Improves indoor air quality", Quantity = 15, Status = ItemStatus.LowStock, CategoryId = 4, UserId = 20 },
        new Item { Id = 21, Name = "Tablet", Description = "Portable touchscreen computer", Quantity = 25, Status = ItemStatus.InStock, CategoryId = 2, UserId = 1 },
        new Item { Id = 26, Name = "Hoodie", Description = "Soft cotton hoodie", Quantity = 60, Status = ItemStatus.InStock, CategoryId = 2, UserId = 2 },
        new Item { Id = 27, Name = "Desk Lamp", Description = "Adjustable LED desk lamp", Quantity = 70, Status = ItemStatus.InStock, CategoryId = 4, UserId = 3 },
        new Item { Id = 28, Name = "Mystery Novel", Description = "Engaging and suspenseful mystery novel", Quantity = 80, Status = ItemStatus.InStock, CategoryId = 3, UserId = 4 },
        new Item { Id = 29, Name = "External Hard Drive", Description = "1TB USB external hard drive", Quantity = 90, Status = ItemStatus.InStock, CategoryId = 1, UserId = 5 },
        new Item { Id = 30, Name = "Sunglasses", Description = "UV protection sunglasses", Quantity = 100, Status = ItemStatus.InStock, CategoryId = 2, UserId = 6 },
        new Item { Id = 31, Name = "Toaster", Description = "4-slice toaster", Quantity = 110, Status = ItemStatus.InStock, CategoryId = 4, UserId = 7 },
        new Item { Id = 32, Name = "Biography Book", Description = "Biography of a historical figure", Quantity = 120, Status = ItemStatus.InStock, CategoryId = 3, UserId = 8 },
        new Item { Id = 33, Name = "Gaming Keyboard", Description = "Mechanical RGB gaming keyboard", Quantity = 130, Status = ItemStatus.InStock, CategoryId = 1, UserId = 9 },
        new Item { Id = 34, Name = "Running Shorts", Description = "Lightweight running shorts", Quantity = 0, Status = ItemStatus.OutOfStock, CategoryId = 2, UserId = 10 },
        new Item { Id = 35, Name = "Vacuum Cleaner", Description = "Bagless cyclone vacuum cleaner", Quantity = 150, Status = ItemStatus.InStock, CategoryId = 4, UserId = 11 },
        new Item { Id = 36, Name = "Self-Help Book", Description = "Guide to personal growth and productivity", Quantity = 160, Status = ItemStatus.InStock, CategoryId = 3, UserId = 12 },
        new Item { Id = 37, Name = "Webcam", Description = "High-definition USB webcam", Quantity = 170, Status = ItemStatus.InStock, CategoryId = 1, UserId = 13 }
        );
    }

    private static void SeedCategories(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Clothing" },
            new Category { Id = 3, Name = "Books" },
            new Category { Id = 4, Name = "Kitchen Appliances" }
        );
    }

    private static void SeedUsers(ModelBuilder modelBuilder)
    {
        var users = new List<User>();
        for (int i = 1; i <= 50; i++)
        {
            users.Add(new User
            {
                UserId = i,
                Username = $"user{i}",
                Password = HashPassword($"password{i}"),
                Email = $"user{i}@example.com"
            });
        }

        modelBuilder.Entity<User>().HasData(users);
    }

    private static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}