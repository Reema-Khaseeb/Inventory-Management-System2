using InventoryManagementSystem.Db.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Db.Configurations;
public class CategoryConfigurations : IEntityTypeConfiguration<Category>
{
    // Configure entity properties, relationships
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        // Primary Key
        builder.HasKey(u => u.Id);

        // Properties
        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd();

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(50);

        // Table Name in Database
        builder.ToTable("Category");
    }
}
