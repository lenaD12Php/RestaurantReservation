using RestaurantReservation.Db.Enums;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.ConsoleUIs;

public class EmployeeConsoleUI
{
    private readonly IEmployeeService _service;
    public EmployeeConsoleUI(IEmployeeService service) => _service = service;

    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine("\n1) Add Employee  \n2) Update FirstName  \n3) Update LastName  #" +
                "\n4) Update Position  \n5) Update Restaurant  \n6) Delete Employee  " +
                "\n7) Get Employee  \n8) Get Employees  \n0) Exit");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1": 
                    await AddEmployeeUI(); 
                    break;
                case "2": 
                    await UpdateEmployeeFirstNameUI(); 
                    break;
                case "3": 
                    await UpdateEmployeeLastNameUI(); 
                    break;
                case "4": 
                    await UpdateEmployeePositionUI(); 
                    break;
                case "5": 
                    await UpdateEmployeeRestaurantUI(); 
                    break;
                case "6": 
                    await DeleteEmployeeUI(); 
                    break;
                case "7": 
                    await GetEmployeeByIdUI(); 
                    break;
                case "8": 
                    await GetEmployeesUI(); 
                    break;
                case "0": 
                    return;
                default: 
                    Console.WriteLine("Pick a valid option."); 
                    break;
            }
        }
    }

    private static int ReadIdOrFail()
    {
        Console.Write("EmployeeId: ");
        return int.TryParse(Console.ReadLine(), out var id) ? id : throw new ArgumentException("Invalid id.");
    }

    private static int ReadRestaurantIdOrFail()
    {
        Console.Write("RestaurantId: ");
        return int.TryParse(Console.ReadLine(), out var restaurantId) ? restaurantId : throw new ArgumentException("Invalid restaurantId.");
    }

    private static Position ReadPositionOrFail()
    {
        Console.WriteLine("Available Positions: (Cashier, Server, Chef, Manager):");
        Console.Write("Position: ");

        if (Enum.TryParse<Position>(Console.ReadLine(), true, out var position)) 
            return position;
        
        throw new ArgumentException($"Invalid position. Please enter one of these: Cashier, Server, Chef, Manager");
    }

    public async Task AddEmployeeUI()
    {
        Console.WriteLine("FirstName: ");
        var firstname = Console.ReadLine();
        Console.WriteLine("LastName: ");
        var lastname = Console.ReadLine();
        var position = ReadPositionOrFail();
        var restaurantId = ReadRestaurantIdOrFail();

        try
        {
            await _service.AddEmployeeAsync(firstname!, lastname!, position!, restaurantId!);
            Console.WriteLine("Employee successfully created!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateEmployeeFirstNameUI()
    {
        try
        {
            var id = ReadIdOrFail();
            Console.WriteLine("FirstName: ");
            var firstname = Console.ReadLine();
            await _service.UpdateEmployeeFirstNameAsync(id, firstname);
            Console.WriteLine("Employee firstname was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateEmployeeLastNameUI()
    {
        try
        {
            var id = ReadIdOrFail();
            Console.WriteLine("LastName: ");
            var lastname = Console.ReadLine();
            await _service.UpdateEmployeeLastNameAsync(id, lastname);
            Console.WriteLine("Employee lasstname was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateEmployeePositionUI()
    {
        try
        {
            var id = ReadIdOrFail();
            var postion = ReadPositionOrFail();
            await _service.UpdateEmployeePositionAsync(id, postion);
            Console.WriteLine("Employee position was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateEmployeeRestaurantUI()
    {
        try
        {
            var id = ReadIdOrFail();
            var restaurantId = ReadRestaurantIdOrFail();
            await _service.UpdateEmployeeRestaurantAsync(id, restaurantId);
            Console.WriteLine("Employee restaurant was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task DeleteEmployeeUI()
    {
        try
        {
            var id = ReadIdOrFail();
            await _service.DeleteEmployeeAsync(id);
            Console.WriteLine("Employee was deleted successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task GetEmployeeByIdUI()
    {
        try
        {
            var id = ReadIdOrFail();

            var employee = await _service.GetEmployeeByIdAsync(id);
            Console.WriteLine($"Employee Id: {employee.EmployeeId},\n   FirstName: {employee.Firstname}," +
            $"\n    LastName: {employee.Lastname},\n    Position: {employee.Position}, " +
            $"\n    RestaurantId: {employee.RestaurantId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task GetEmployeesUI()
    {
        var employees = await _service.GetEmployeesAsync();
        foreach (var employee in employees)
        {
            Console.WriteLine($"Employee Id: {employee.EmployeeId},\n   FirstName: {employee.Firstname}," +
            $"\n    LastName: {employee.Lastname},\n    Position: {employee.Position}, " +
            $"\n    RestaurantId: {employee.RestaurantId}");
        }
    }
}
