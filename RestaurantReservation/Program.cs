using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestaurantReservation.ConsoleUIs;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Services;


var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddDbContext<RestaurantReservationDbContext>(opt =>
            opt.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RestaurantReservationCore;Integrated Security=true"));

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IMenuItemRepository, MenuItemRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        services.AddScoped<ITableRepository, TableRepository>();
        services.AddScoped<IReservationWithDetailsRepository, ReservationWithDetailsRepository>();
        services.AddScoped<IEmployeesWithRestaurantDetailsRepository, EmployeesWithRestaurantDetailsRepository>();

        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IMenuItemService, MenuItemService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderItemService, OrderItemService>();
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<IRestaurantService, RestaurantService>();
        services.AddScoped<ITableService, TableService>();
        services.AddScoped<IReservationWithDetailsService, ReservationWithDetailsService>();
        services.AddScoped<IEmployeesWithRestaurantDetailsService, EmployeesWithRestaurantDetailsService>();

        services.AddScoped<CustomerConsoleUI>();
        services.AddScoped<EmployeeConsoleUI>();
        services.AddScoped<MenuItemConsoleUI>();
        services.AddScoped<OrderConsoleUI>();
        services.AddScoped<OrderItemConsoleUI>();
        services.AddScoped<ReservationConsoleUI>();
        services.AddScoped<RestaurantConsoleUI>();
        services.AddScoped<TableConsoleUI>();
        services.AddScoped<ReservationWithDetailsConsoleUI>();
        services.AddScoped<EmployeeWithDetailsConsoleUI>();

    })
    .Build();

using var scope = host.Services.CreateScope();
var sp = scope.ServiceProvider;

while (true)
{
    Console.Clear();
    Console.WriteLine("----- Restaurant Reservation System -----");
    Console.WriteLine("1) Customer");
    Console.WriteLine("2) Employee");
    Console.WriteLine("3) MenuItem");
    Console.WriteLine("4) Order");
    Console.WriteLine("5) OrderItem");
    Console.WriteLine("6) Reservation");
    Console.WriteLine("7) Restaurant");
    Console.WriteLine("8) Table");
    Console.WriteLine("9) ReservationWithDetails");
    Console.WriteLine("10) EmployeeWithDetails");
    Console.WriteLine("0) Exit");

    Console.Write("\nChoose: ");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1": 
            await sp.GetRequiredService<CustomerConsoleUI>().RunAsync(); 
            break;
        case "2": 
            await sp.GetRequiredService<EmployeeConsoleUI>().RunAsync(); 
            break;
        case "3": 
            await sp.GetRequiredService<MenuItemConsoleUI>().RunAsync(); 
            break;
        case "4": 
            await sp.GetRequiredService<OrderConsoleUI>().RunAsync(); 
            break;
        case "5": 
            await sp.GetRequiredService<OrderItemConsoleUI>().RunAsync(); 
            break;
        case "6": 
            await sp.GetRequiredService<ReservationConsoleUI>().RunAsync(); 
            break;
        case "7": 
            await sp.GetRequiredService<RestaurantConsoleUI>().RunAsync(); 
            break;
        case "8": 
            await sp.GetRequiredService<TableConsoleUI>().RunAsync(); 
            break;
        case "9":
            await sp.GetRequiredService<ReservationWithDetailsConsoleUI>().RunAsync();
            break;
        case "10":
            await sp.GetRequiredService<EmployeeWithDetailsConsoleUI>().RunAsync();
            break;
        case "0": 
            return;
        default:
            Console.WriteLine("Invalid choice. Try again");
            Console.ReadLine();
            break;
    }
}
