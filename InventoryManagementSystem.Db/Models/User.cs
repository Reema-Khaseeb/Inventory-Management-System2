﻿using InventoryManagementSystem.Common.Enums;

namespace InventoryManagementSystem.Db.Models;
public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }
    public ICollection<Item> Items { get; set; } // Navigation property
}
