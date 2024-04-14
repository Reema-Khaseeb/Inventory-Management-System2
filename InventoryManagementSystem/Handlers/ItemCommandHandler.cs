using InventoryManagementSystem.Common.Enums;
using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Dtos;
using InventoryManagementSystem.Services.Interfaces;

namespace InventoryManagementSystem.Handlers;

public class ItemCommandHandler
{
    public static async Task ItemManagement(IItemService itemService)
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("\nItem Management:");
            Console.WriteLine("1. Create New Item");
            Console.WriteLine("2. Retrieve Item by ID");
            Console.WriteLine("3. Update an Item");
            Console.WriteLine("4. Delete an Item");
            Console.WriteLine("5. List All Items");
            Console.WriteLine("6. Back to Main Menu");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await CreateItemAsync(itemService);
                    break;
                case "2":
                    await RetrieveItemByIdAsync(itemService);
                    break;
                case "3":
                    await UpdateItemAsync(itemService);
                    break;
                case "4":
                    await DeleteItemAsync(itemService);
                    break;
                case "5":
                    await RetrieveAllItemsAsync(itemService);
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

    static async Task CreateItemAsync(IItemService itemService)
    {
        try
        {
            Console.WriteLine("Enter details for the new item:");

            Console.Write("Name: ");
            var name = Console.ReadLine();

            Console.Write("Description: ");
            var description = Console.ReadLine();

            Console.Write("Quantity: ");
            int quantity;
            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.Write("Please enter a valid number for quantity: ");
            }

            Console.Write("User ID: ");
            int userId;
            while (!int.TryParse(Console.ReadLine(), out userId))
            {
                Console.Write("Please enter a valid number for user Id: ");
            }

            Console.Write("Category ID: ");
            int categoryId;
            while (!int.TryParse(Console.ReadLine(), out categoryId))
            {
                Console.Write("Please enter a valid number for category Id: ");
            }

            var newItem = new Item
            {
                Name = name,
                Description = description,
                Quantity = quantity,
                UserId = userId,
                CategoryId = categoryId
            };

            var createdItem = await itemService.CreateItemAsync(newItem);
            Console.WriteLine($"New item created with ID: {createdItem.Id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static async Task RetrieveItemByIdAsync(IItemService itemService)
    {
        try
        {
            Console.Write("\nEnter the ID of the item to retrieve: ");
            int itemId;
            while (!int.TryParse(Console.ReadLine(), out itemId))
            {
                Console.Write("Please enter a valid number for item Id: ");
            }

            var item = await itemService.GetItemAsync(itemId);
            Console.WriteLine($"\nRetrieved item:");
            Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Description: {item.Description}, " +
                              $"Quantity: {item.Quantity}, Category ID: {item.CategoryId}, User ID: {item.UserId}, " +
                              $"Status: {item.Status}");
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("Item not found. Please enter a valid item ID.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }

    static async Task UpdateItemAsync(IItemService itemService)
    {
        try
        {

            Console.Write("\nEnter the ID of the item to update: ");
            int itemIdToUpdate;
            while (!int.TryParse(Console.ReadLine(), out itemIdToUpdate))
            {
                Console.Write("Please enter a valid number for item Id: ");
            }

            Console.WriteLine("Enter updated item details:");
            Console.Write("Name: ");
            var name = Console.ReadLine();

            Console.Write("Description: ");
            var description = Console.ReadLine();

            Console.Write("Quantity: ");
            int quantity;
            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.Write("Please enter a valid number for quantity: ");
            }

            Console.Write("Status (InStock = 0, LowStock = 1, OutOfStock = 2): ");
            var status = (ItemStatus)Enum.Parse(typeof(ItemStatus), Console.ReadLine());

            Console.Write("User ID: ");
            int userId;
            while (!int.TryParse(Console.ReadLine(), out userId))
            {
                Console.Write("Please enter a valid number for user Id: ");
            }

            Console.Write("Category ID: ");
            int categoryId;
            while (!int.TryParse(Console.ReadLine(), out categoryId))
            {
                Console.Write("Please enter a valid number for category Id: ");
            }

            var updateItemDto = new ItemDto(name, description, quantity, status, userId, categoryId);

            await itemService.UpdateItemAsync(itemIdToUpdate, updateItemDto);
            Console.WriteLine($"\nItem with ID: {itemIdToUpdate} has been updated.");
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("Item not found. Please enter a valid item ID.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }

    static async Task DeleteItemAsync(IItemService itemService)
    {
        try
        {
            Console.Write("\nEnter the ID of the item to delete: ");
            int itemIdToDelete = int.Parse(Console.ReadLine());
            await itemService.DeleteItemAsync(itemIdToDelete);
            Console.WriteLine($"\nItem with ID: {itemIdToDelete} has been deleted.");
        }
        catch (KeyNotFoundException knfEx)
        {
            Console.WriteLine($"Item not found: {knfEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while deleting the item: {ex.Message}");
        }
    }

    static async Task RetrieveAllItemsAsync(IItemService itemService)
    {
        try
        {
            Console.WriteLine("\nRetrieving all items...");
            var items = await itemService.GetItemsAsync();
            foreach (var inventoryItem in items)
            {
                Console.WriteLine($"ID: {inventoryItem.Id}, Name: {inventoryItem.Name}, " +
                                  $"Quantity: {inventoryItem.Quantity}, Status: {inventoryItem.Status}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while retrieving items: {ex.Message}");
        }
    }

}
