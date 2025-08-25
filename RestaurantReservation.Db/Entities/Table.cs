using RestaurantReservation.Db.Enums;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Entities;

public class Table
{
    public int TableId { get; set; }
    [Required]
    public Capacity Capacity {  get; set; }

    public Restaurant Restaurant { get; set; }
    [Required]
    public int RestaurantId { get; set; }
}
