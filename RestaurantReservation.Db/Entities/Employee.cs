using RestaurantReservation.Db.Enums;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Entities;

public class Employee
{
    public Employee()
    {
        Orders = new List<Order>();
    }

    public int EmployeeId { get; set; }
    [Required]
    public string Firstname {  get; set; }
    [Required]
    public string Lastname { get; set; }
    [Required]
    public Position Position { get; set; }

    public Restaurant Restaurant { get; set; }
    [Required]
    public int RestaurantId { get; set; }
    public List<Order> Orders { get; set; }

}
