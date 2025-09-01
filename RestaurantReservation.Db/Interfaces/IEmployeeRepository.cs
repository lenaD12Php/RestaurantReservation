using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces;

public interface IEmployeeRepository
{
    Task AddEmployeeAsync(Employee employee);
    Task<Employee?> GetEmployeeByIdAsync(int employeeId);
    Task<List<Employee>> GetEmployeesAsync();
    Task UpdateEmployeeAsync(Employee employee);
    Task DeleteEmployeeAsync(Employee employee);
}
