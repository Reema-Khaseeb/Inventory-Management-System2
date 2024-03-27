﻿using InventoryManagementSystem.Db.Models;
using InventoryManagementSystem.Db.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagementSystem.Db.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
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

        //// Seed Data
        builder.HasData(SeedData.SeedUsers());

        // Table Name in Database
        builder.ToTable("User");
    }
}
