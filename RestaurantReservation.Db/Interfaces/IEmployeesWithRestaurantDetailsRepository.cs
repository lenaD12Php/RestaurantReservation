using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces;

public interface IEmployeesWithRestaurantDetailsRepository
{
    Task<List<EmployeesWithRestaurantDetails>> GetEmployeesWithRestaurantDetailsAsync();
}
