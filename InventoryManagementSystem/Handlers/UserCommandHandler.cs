using InventoryManagementSystem.Common.Enums;
using InventoryManagementSystem.Dtos.User;
using InventoryManagementSystem.Services.Interfaces;

namespace InventoryManagementSystem.Handlers;

public class UserCommandHandler
{

    public static async Task UserManagement(IUserService userService)
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("\nUser Management:");
            Console.WriteLine("1. Register User");
            Console.WriteLine("2. Get User by ID");
            Console.WriteLine("3. Get User by Username");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await RegisterUserAsync(userService);
                    break;
                case "2":
                    await GetUserByIdAsync(userService);
                    break;
                case "3":
                    await GetUserByUsernameAsync(userService);
                    break;
                case "4":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    static async Task RegisterUserAsync(IUserService userService)
    {
        Console.WriteLine("\n--- Register New User ---");
        Console.WriteLine("Enter username:");
        var username = Console.ReadLine();
        Console.WriteLine("Enter password:");
        var password = Console.ReadLine();
        Console.WriteLine("Enter email:");
        var email = Console.ReadLine();
        Console.WriteLine("Enter user role (User = 0, Admin = 1):");
        var role = (UserRole)Enum.Parse(typeof(UserRole), Console.ReadLine());


        var userRequest = new UserRequest(username, password, email, role);

        try
        {
            var userResponse = await userService.RegisterUserAsync(userRequest);
            Console.WriteLine($"User '{userResponse.Username}' registered successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error registering user: {ex.Message}");
        }
    }

    static async Task GetUserByIdAsync(IUserService userService)
    {
        try
        {
            Console.Write("Enter User ID: ");
            int userId;
            while (!int.TryParse(Console.ReadLine(), out userId))
            {
                Console.Write("Please enter a valid number for user Id: ");
            }

            var user = await userService.GetUserByIdAsync(userId);
            Console.WriteLine($"User Found: {user.Username}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching user: {ex.Message}");
        }
    }

    static async Task GetUserByUsernameAsync(IUserService userService)
    {
        try
        {
            Console.Write("Enter Username: ");
            var username = Console.ReadLine();
            var user = await userService.GetUserByUsernameAsync(username);
            Console.WriteLine($"User Found: {user.Username}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching user: {ex.Message}");
        }
    }

}
