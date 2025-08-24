using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Entities;

public class Customer
{
    public Customer()
    {
        Reservations = new List<Reservation>();
    }

    public int CustomerId {  get; set; }
    [Required]
    public string Firstname { get; set; }
    [Required]
    public string Lastname { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [Phone]
    public string PhoneNumber { get; set; }

    public List<Reservation> Reservations { get; set; }
}
