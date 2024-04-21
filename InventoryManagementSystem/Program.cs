using InventoryManagementSystem.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InventoryManagementSystem.Handlers;
using InventoryManagementSystem.Utilities;

// Build a configuration
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

// Set up the DI container
var serviceCollection = new ServiceCollection();
ServiceConfigurator.ConfigureServices(serviceCollection, configuration);

// Build a service provider
var serviceProvider = serviceCollection.BuildServiceProvider();

// create services needed
var authenticationService = serviceProvider.GetService<IAuthenticationService>();
var itemService = serviceProvider.GetService<IItemService>();
var userService = serviceProvider.GetService<IUserService>();
var categoryService = serviceProvider.GetService<ICategoryService>();

bool exit = false;
while (!exit)
{
    Console.WriteLine("\nMain Menu:");
    Console.WriteLine("1. User Management");
    Console.WriteLine("2. Item Management");
    Console.WriteLine("3. Category Management");
    Console.WriteLine("4. Authentication");
    Console.WriteLine("5. Exit");
    Console.Write("Select an option: ");
    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            await UserCommandHandler.UserManagement(userService);
            break;
        case "2":
            await ItemCommandHandler.ItemManagement(itemService);
            break;
        case "3":
            await CategoryCommandHandler.CategoryManagement(categoryService);
            break;
        case "4":
            await AuthenticationCommandHandler.AuthenticationManagement(authenticationService);
            break;
        case "5":
            exit = true;
            break;
        default:
            Console.WriteLine("Invalid option, please try again.");
            break;
    }
}
