using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces;

public interface IEmployeesWithRestaurantDetailsService
{
    Task<List<EmployeesWithRestaurantDetails>> GetEmployeesWithRestaurantDetailsAsync();
}
