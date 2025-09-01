using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Enums;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Services;


public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;


    public EmployeeService(IEmployeeRepository repository) => _repository = repository;
   

    public async Task AddEmployeeAsync(string firstName, string lastName, Position position, int restaurantId)
    {
        var employee = new Employee
        {
            Firstname = firstName,
            Lastname = lastName,
            Position = position,
            RestaurantId = restaurantId
        };

       await _repository.AddEmployeeAsync(employee);
    }

    public async Task DeleteEmployeeAsync(int employeeId)
    {
        var employee = await _repository.GetEmployeeByIdAsync(employeeId);

        await _repository.DeleteEmployeeAsync(employee);
    }

    public async Task<List<Employee>> GetEmployeesAsync()
    {
         return await _repository.GetEmployeesAsync();
    }

    public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
    {
        return await _repository.GetEmployeeByIdAsync(employeeId);
    }

    public async Task UpdateEmployeeFirstNameAsync(int employeeId, string firstName)
    {
        var employee = await _repository.GetEmployeeByIdAsync(employeeId);

        employee.Firstname = firstName;

        await _repository.UpdateEmployeeAsync(employee);
    }
    
    public async Task UpdateEmployeeLastNameAsync(int employeeId, string lastName)
    {
        var employee = await _repository.GetEmployeeByIdAsync(employeeId);

        employee.Lastname = lastName;

        await _repository.UpdateEmployeeAsync(employee);
    }

    public async  Task UpdateEmployeePositionAsync(int employeeId, Position position)
    {
        var employee = await _repository.GetEmployeeByIdAsync(employeeId);

        employee.Position = position;

        await _repository.UpdateEmployeeAsync(employee);
    }

    public async Task UpdateEmployeeRestaurantAsync(int employeeId, int restaurantId)
    {
        var employee = await _repository.GetEmployeeByIdAsync(employeeId);

        employee.RestaurantId = restaurantId;

        await _repository.UpdateEmployeeAsync(employee);
    }
}
