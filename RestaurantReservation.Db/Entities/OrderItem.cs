using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Entities;

public class OrderItem
{
    public int OrderItemId {  get; set; }
    [Required]
    public int OrderId { get; set; }
    public Order Order { get; set; }
    [Required]
    public int MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; }
    [Required]
    public int Quantity { get; set; }
}
