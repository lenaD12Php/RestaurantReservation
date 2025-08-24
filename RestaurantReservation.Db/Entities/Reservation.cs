using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Entities;

public class Reservation
{
    public Reservation() 
    {
        orders = new List<Order>();
    }

    public int ReservationId { get; set; }
    [Required]
    public DateTime ReservationDate { get; set; }
    [Required]
    public int PartySize { get; set; }

    public Restaurant Restaurant { get; set; }
    [Required]
    public int RestaurantId { get; set; }
    public Customer Customer { get; set; }
    [Required]
    public int CustomerId { get; set; }
    public Table Table { get; set; }
    [Required]
    public int TableId { get; set; }

    public List<Order> orders { get; set; }
}
