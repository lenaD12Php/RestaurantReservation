using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Entities;

public class Restaurant
{
    public Restaurant()
    {
        Tables = new List<Table>();
        Reservations = new List<Reservation>();
        Employees = new List<Employee>();
        MenuItems = new List<MenuItem>();
    }

    public int RestaurantId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    [Phone]
    public string PhoneNumber { get; set; }
    public string OpeningHours { get; set; }
    public List<Table> Tables { get; set; }
    public List<Reservation> Reservations { get; set; }
    public List<Employee> Employees { get; set; }
    public List<MenuItem> MenuItems { get; set; }
}
