using InventoryManagementSystem.Dtos.Login;
using InventoryManagementSystem.Services.Interfaces;

namespace InventoryManagementSystem.Handlers;

public class AuthenticationCommandHandler
{
    public static async Task AuthenticationManagement(IAuthenticationService authenticationService)
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("\nAuthentication:");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Back to Main Menu");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await LoginAsync(authenticationService);
                    break;
                case "2":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    static async Task LoginAsync(IAuthenticationService authenticationService)
    {
        Console.WriteLine("\n--- User Login ---");
        Console.Write("Enter username: ");
        var username = Console.ReadLine();
        Console.Write("Enter password: ");
        var password = Console.ReadLine();

        try
        {
            var token = await authenticationService.LoginAsync(new LoginRequest(username, password));
            Console.WriteLine($"Login successful. Token: {token}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Login failed: {ex.Message}");
        }
    }

}
