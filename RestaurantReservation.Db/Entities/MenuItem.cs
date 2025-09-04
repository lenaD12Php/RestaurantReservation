using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Entities;

public class MenuItem
{
    public MenuItem()
    {
        OrderItems = new List<OrderItem>();
    }

    public int MenuItemId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public decimal Price { get; set; }
    public Restaurant Restaurant { get; set; }
    [Required]
    public int RestaurantId { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}
