using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Entities;

public class Order
{
    public Order()
    {
        OrderItems = new List<OrderItem>();
    }

    public int OrderId { get; set; }
    [Required]
    public DateTime OrderDate { get; set; }
    [Required]
    public decimal TotalAmount { get; set; }
    public Reservation Reservation { get; set; }
    [Required]
    public int ReservationId { get; set; }
    public Employee Employee { get; set; }
    [Required]
    public int EmployeeId { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}
