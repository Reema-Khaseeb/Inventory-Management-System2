using InventoryManagementSystem.Db;
using InventoryManagementSystem.Services.Interfaces;
using InventoryManagementSystem.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using InventoryManagementSystem.Db.Repositories.Interfaces;
using InventoryManagementSystem.Db.Repositories;
using InventoryManagementSystem.MappingProfiles;
using Microsoft.OpenApi.Models;
using System.Reflection;
using FluentValidation.AspNetCore;

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
        ConfigureAutoMapper(services);
        ConfigureScopedServices(services);
        ConfigureRepositories(services);
        ConfigureDbContext(services);
        ConfigureControllers(services);
        ConfigureSwagger(services);
    }

    // Configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();

        // Add the Controller to the API
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        //to get more detailed error information
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        ConfigureSwaggerUI(app);
    }

    private void ConfigureDbContext(IServiceCollection services)
    {
        var connectionString = Configuration.GetConnectionString("PostgresConnection");

        // Add DbContext to the DI container
        services.AddDbContext<InventoryManagementSystemDbContext>(options =>
            options.UseNpgsql(connectionString));
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

    private void ConfigureAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserProfile));
    }

    private void ConfigureControllers(IServiceCollection services)
    {
        services.AddControllers()
        .AddFluentValidation(fv => fv
        .RegisterValidatorsFromAssemblyContaining<Startup>());
    }

    private void ConfigureScopedServices(IServiceCollection services)
    {
        services.AddScoped<InventoryManagementSystemDbContext>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IItemService, ItemService>();
    }

    private void ConfigureRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
    }

    private void ConfigureSwaggerUI(IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory Management System API v1");
        });
    }

    private void ConfigureSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Inventory Management System API v1",
                Version = "v1"
            });
            // Include XML comments for Swagger documentation.
            // Set comments path for Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below. Example: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
        });
    }
}
