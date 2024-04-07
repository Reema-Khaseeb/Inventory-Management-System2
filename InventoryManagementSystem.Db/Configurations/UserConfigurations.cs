using InventoryManagementSystem.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagementSystem.Db.Configurations;
public class UserConfigurations : IEntityTypeConfiguration<User>
{
    // Configure entity properties, relationships
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Primary Key
        builder.HasKey(u => u.UserId);

        // Properties
        builder.Property(u => u.UserId)
            .ValueGeneratedOnAdd();

        builder.Property(u => u.Username)
            .IsRequired();

        builder.Property(u => u.Password)
            .IsRequired();
        
        builder.Property(u => u.Email)
            .IsRequired();

        // Table Name in Database
        builder.ToTable("User");
    }
}
