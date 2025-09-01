using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.ConsoleUIs;

public class OrderConsoleUI
{
    private readonly IOrderService _service;
    public OrderConsoleUI(IOrderService service) => _service = service;

    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine("\n1) Add Order  \n2) Update OrderDate  \n3) Update TotalAmount  " +
                "\n4) Update Reservation  \n5) Update Employee  \n6) Delete Order  " +
                "\n7) Get Order  \n8) Get Orders  \n0) Exit");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    await AddOrderUI();
                    break;
                case "2":
                    await UpdateOrderOrderDateUI();
                    break;
                case "3":
                    await UpdateReservationUI();
                    break;
                case "4":
                    await UpdateOrderTotalAmountUI();
                    break;
                case "5":
                    await UpdateOrderEmployeeUI();
                    break;
                case "6":
                    await DeleteOrderUI();
                    break;
                case "7":
                    await GetOrderByIdUI();
                    break;
                case "8":
                    await GetOrdersUI();
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
        Console.Write("OrderId: ");
        return int.TryParse(Console.ReadLine(), out var id) ? id : throw new ArgumentException("Invalid id.");
    }

    private static decimal ReadTotalAmountOrFail()
    {
        Console.Write("Total Amout: ");
        return decimal.TryParse(Console.ReadLine(), out var totalAmount) ? totalAmount : throw new ArgumentException("Invalid total amount.");
    }

    private static int ReadEmployeeIdOrFail()
    {
        Console.Write("EmployeeId: ");
        return int.TryParse(Console.ReadLine(), out var employeeId) ? employeeId : throw new ArgumentException("Invalid employeeId.");
    }

    private static int ReadReservationIdOrFail()
    {
        Console.Write("ReservationId: ");
        return int.TryParse(Console.ReadLine(), out var reservationId) ? reservationId : throw new ArgumentException("Invalid reservationId.");
    }

    private static DateTime ReadOrderDateOrFail()
    {
        Console.Write("OrderDate(yyyy-MM-dd HH:mm:ss): ");
        return DateTime.TryParse(Console.ReadLine(), out var orderDate) ? orderDate : throw new ArgumentException("Invalid orderDate.");
    }

    public async Task AddOrderUI()
    {
        var orderDate = ReadOrderDateOrFail();
        var totalAmount = ReadTotalAmountOrFail();
        var reservationId = ReadReservationIdOrFail();
        var employeeId = ReadEmployeeIdOrFail();

        try
        {
            await _service.AddOrderAsync(orderDate!, totalAmount!, reservationId!, employeeId!);
            Console.WriteLine("Order successfully created!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateOrderOrderDateUI()
    {
        try
        {
            var id = ReadIdOrFail();
            var orderDate = ReadOrderDateOrFail();
            await _service.UpdateOrderOrderDateAsync(id, orderDate);
            Console.WriteLine("Order date was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateReservationUI()
    {
        try
        {
            var id = ReadIdOrFail();
            var reservationId = ReadReservationIdOrFail();
            await _service.UpdateOrderReservationAsync(id, reservationId);
            Console.WriteLine("Order reservation was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateOrderTotalAmountUI()
    {
        try
        {
            var id = ReadIdOrFail();
            var totalAmount = ReadTotalAmountOrFail();
            await _service.UpdateOrderTotalAmountAsync(id, totalAmount);
            Console.WriteLine("Order TotalAmount was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateOrderEmployeeUI()
    {
        try
        {
            var id = ReadIdOrFail();
            var employeeId = ReadEmployeeIdOrFail();
            await _service.UpdateOrderEmployeeAsync(id, employeeId);
            Console.WriteLine("Order employee was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task DeleteOrderUI()
    {
        try
        {
            var id = ReadIdOrFail();
            await _service.DeleteOrderAsync(id);
            Console.WriteLine("Order was deleted successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task GetOrderByIdUI()
    {
        try
        {
            var id = ReadIdOrFail();

            var order = await _service.GetOrderByIdAsync(id);
            Console.WriteLine($"OrderId: {order.OrderId},\n   OrderDate: {order.OrderDate}," +
            $"\n    TotalAmount: {order.TotalAmount},\n    ReservationId: {order.ReservationId}, " +
            $"\n    EmployeeId: {order.EmployeeId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task GetOrdersUI()
    {
        var orders = await _service.GetOrdersAsync();
        foreach (var order in orders)
        {
            Console.WriteLine($"OrderId: {order.OrderId},\n   OrderDate: {order.OrderDate}," +
            $"\n    TotalAmount: {order.TotalAmount},\n    ReservationId: {order.ReservationId}, " +
            $"\n    EmployeeId: {order.EmployeeId}");
        }
    }
}

