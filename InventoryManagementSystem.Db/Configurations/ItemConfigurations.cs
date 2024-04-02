using InventoryManagementSystem.Db.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Db.Configurations;
public class ItemConfigurations : IEntityTypeConfiguration<Item>
{
    // Configure entity properties, relationships
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        // Primary Key
        builder.HasKey(u => u.Id);

        // Properties
        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd();

        builder.Property(u => u.Name)
            .IsRequired();

        builder.Property(u => u.Quantity)
            .IsRequired();

        // Relationships and Constraints
        builder.HasOne(i => i.User)
            .WithMany(u => u.Items)
            .HasForeignKey(i => i.UserId);
            
        // Table Name in Database
        builder.ToTable("Item");
    }
}
