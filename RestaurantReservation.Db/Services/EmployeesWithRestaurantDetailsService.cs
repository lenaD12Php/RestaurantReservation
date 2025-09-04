using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Services;

public class EmployeesWithRestaurantDetailsService : IEmployeesWithRestaurantDetailsService
{
    private readonly IEmployeesWithRestaurantDetailsRepository _repository;

    public EmployeesWithRestaurantDetailsService(IEmployeesWithRestaurantDetailsRepository repository) => _repository = repository;

    public async Task<List<EmployeesWithRestaurantDetails>> GetEmployeesWithRestaurantDetailsAsync()
    { 
        return await _repository.GetEmployeesWithRestaurantDetailsAsync();
    }
}
