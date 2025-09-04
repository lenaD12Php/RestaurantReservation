using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.ConsoleUIs;

public class EmployeeWithDetailsConsoleUI
{
    private readonly IEmployeesWithRestaurantDetailsService _service;
    public EmployeeWithDetailsConsoleUI(IEmployeesWithRestaurantDetailsService service) => _service = service;

    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine("\n1) Get Employees With Restaurant Details  \n0) Exit");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    await GetEmployeesWithRestaurantDetailsUI();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Pick a valid option.");
                    break;
            }
        }
    }

    public async Task GetEmployeesWithRestaurantDetailsUI()
    {
        var employeesWithDetails = await _service.GetEmployeesWithRestaurantDetailsAsync();

        foreach (var emp in employeesWithDetails)
        {
            Console.WriteLine($" EmployeeId: {emp.EmployeeId},\n    EmployeeName: {emp.EmployeeName}," +
                $"\n    EmployeePosition: {emp.EmployeePosition},\n     RestaurantId: {emp.RestaurantId}," +
                $"\n    RestaurantName: {emp.RestaurantName},\n    RestaurantAddress: {emp.RestaurantAddress}," +
                $"\n    RestaurantPhone: {emp.RestaurantPhone},\n    RestauranrtOpeningHours: {emp.RestauranrtOpeningHours}");
        }
    }
}
