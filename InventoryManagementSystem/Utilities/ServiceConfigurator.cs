using InventoryManagementSystem.Db.Repositories.Interfaces;
using InventoryManagementSystem.Db.Repositories;
using InventoryManagementSystem.Db;
using InventoryManagementSystem.MappingProfiles;
using InventoryManagementSystem.Services.Interfaces;
using InventoryManagementSystem.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Utilities;

public class ServiceConfigurator
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = "your connection string";
        var secretKey = "your secret key";

        // Register the IConfiguration instance
        services.AddSingleton<IConfiguration>(configuration);

        // Setup JWT Token Generator with hardcoded secret key
        var tokenValidationParameters = new TokenValidationParametersBuilder()
            .WithSecretKey(secretKey)
            .WithDefaultValidationParameters()
            .Build();

        // Add services to the service collection
        services.AddDbContext<InventoryManagementSystemDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddLogging();

        services.AddScoped<InventoryManagementSystemDbContext>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IItemSearchService, ItemSearchService>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        services.AddAutoMapper(typeof(UserProfile));
        services.AddAuthorization();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGeneratorWithoutConfigurations>();

        //// Setup the token generator
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParametersBuilder()
                        .WithSecretKey(secretKey)
                        .WithDefaultValidationParameters()
                        .Build();
                });
    }
}
