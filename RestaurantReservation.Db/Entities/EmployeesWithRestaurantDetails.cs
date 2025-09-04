using RestaurantReservation.Db.Enums;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Entities;

public sealed class EmployeesWithRestaurantDetails
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public string EmployeePosition { get; set; }
    public int RestaurantId { get; set; }
    public string RestaurantName { get; set; }
    public string RestaurantAddress { get; set; }
    public string RestaurantPhone { get; set; }
    public string RestauranrtOpeningHours { get; set; }
}
