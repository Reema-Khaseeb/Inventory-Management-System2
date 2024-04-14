using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Dtos;
using InventoryManagementSystem.Services.Interfaces;

namespace InventoryManagementSystem.Handlers;

public class CategoryCommandHandler
{
    public static async Task CategoryManagement(ICategoryService categoryService)
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("\nCategory Management:");
            Console.WriteLine("1. Create New Category");
            Console.WriteLine("2. Retrieve Category by ID");
            Console.WriteLine("3. Update a Category");
            Console.WriteLine("4. Delete a Category");
            Console.WriteLine("5. List All Categories");
            Console.WriteLine("6. Back to Main Menu");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await CreateCategoryAsync(categoryService);
                    break;
                case "2":
                    await GetCategoryAsync(categoryService);
                    break;
                case "3":
                    await UpdateCategoryAsync(categoryService);
                    break;
                case "4":
                    await DeleteCategoryAsync(categoryService);
                    break;
                case "5":
                    await ListCategoriesAsync(categoryService);
                    break;
                case "6":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    static async Task CreateCategoryAsync(ICategoryService categoryService)
    {
        Console.Write("Enter category name: ");
        var name = Console.ReadLine();
        var categoryDto = new Category { Name = name };
        var newCategory = await categoryService.CreateCategoryAsync(categoryDto);

        Console.WriteLine($"Category created with ID: {newCategory.Id}");
    }

    static async Task GetCategoryAsync(ICategoryService categoryService)
    {
        Console.Write("Enter category ID: ");
        var id = int.Parse(Console.ReadLine());
        var category = await categoryService.GetCategoryAsync(id);

        Console.WriteLine($"Category: {category.Name}");
    }

    static async Task ListCategoriesAsync(ICategoryService categoryService)
    {
        var categories = await categoryService.GetCategoriesAsync();

        foreach (var category in categories)
        {
            Console.WriteLine($"Name: {category.Name}");
        }
    }

    static async Task UpdateCategoryAsync(ICategoryService categoryService)
    {
        Console.Write("Enter category ID to update: ");
        var id = int.Parse(Console.ReadLine());
        Console.Write("Enter new category name: ");
        var name = Console.ReadLine();
        var categoryDto = new CategoryDto(name);

        await categoryService.UpdateCategoryAsync(id, categoryDto);
        Console.WriteLine("Category updated successfully.");
    }

    static async Task DeleteCategoryAsync(ICategoryService categoryService)
    {
        Console.Write("Enter category ID to delete: ");
        var id = int.Parse(Console.ReadLine());

        await categoryService.DeleteCategoryAsync(id);
        Console.WriteLine("Category deleted successfully.");
    }

}
