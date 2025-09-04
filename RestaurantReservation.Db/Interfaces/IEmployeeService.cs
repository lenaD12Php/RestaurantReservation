using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Enums;

namespace RestaurantReservation.Db.Interfaces;

public interface IEmployeeService
{
    Task AddEmployeeAsync(string firstName, string lastName, Position position, int restaurantId);
    Task UpdateEmployeeFirstNameAsync(int employeeId, string firstName);
    Task UpdateEmployeeLastNameAsync(int employeeId, string lastName);
    Task UpdateEmployeePositionAsync(int employeeId, Position position);
    Task UpdateEmployeeRestaurantAsync(int employeeId, int restaurantId);
    Task<Employee> GetEmployeeByIdAsync(int employeeId);
    Task<List<Employee>> GetEmployeesAsync();
    Task<List<Employee>> GetManagersAsync();
    Task DeleteEmployeeAsync(int employeeId);
}
