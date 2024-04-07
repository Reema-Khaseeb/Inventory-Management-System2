using InventoryManagementSystem.Common.Enums;

namespace InventoryManagementSystem.Db.Models;
public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public ItemStatus Status { get; set; }
    // Foreign key properties
    public int UserId { get; set; }
    // Navigation properties
    public User User { get; set; }
}
