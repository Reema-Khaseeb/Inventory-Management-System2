using InventoryManagementSystem.Db.Configurations;
using InventoryManagementSystem.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Db;
public class InventoryManagementSystemDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public InventoryManagementSystemDbContext(
        DbContextOptions<InventoryManagementSystemDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships and constraints
        modelBuilder.ApplyConfiguration(new UserConfigurations());

        base.OnModelCreating(modelBuilder);
    }
}
