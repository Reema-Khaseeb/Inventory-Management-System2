using InventoryManagementSystem.Services.Interfaces;
using InventoryManagementSystem.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace InventoryManagementSystem.Api;
public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // Add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        ConfigureAuthentication(services);
        ConfigureAuthorization(services);
    }

    private void ConfigureAuthentication(IServiceCollection services)
    {
        var secretKey = Configuration["Authentication:SecretKey"];

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParametersBuilder()
                    .WithSecretKey(secretKey)
                    .WithDefaultValidationParameters()
                    .Build();
            });
    }

    private void ConfigureAuthorization(IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    }
}
