using RestaurantReservation.Db.Enums;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.ConsoleUIs;

public class TableConsoleUI
{
    private readonly ITableService _service;
    public TableConsoleUI(ITableService service) => _service = service;

    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine("\n1) Add Table  \n2) Update Capacity  \n3) Update Restaurant  " +
                "\n4) Delete Table  \n5) Get Table  \n6) Get Tables  \n0) Exit");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    await AddTableUI();
                    break;
                case "2":
                    await UpdateTableCapacityUI();
                    break;
                case "3":
                    await UpdateTableRestaurantUI();
                    break;
                case "4":
                    await DeleteTableUI();
                    break;
                case "5":
                    await GetTableByIdUI();
                    break;
                case "6":
                    await GetTablesUI();
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
        Console.Write("TableId: ");
        return int.TryParse(Console.ReadLine(), out var id) ? id : throw new ArgumentException("Invalid id.");
    }

    private static int ReadRestaurantIdOrFail()
    {
        Console.Write("RestaurantId: ");
        return int.TryParse(Console.ReadLine(), out var restaurantId) ? restaurantId : throw new ArgumentException("Invalid restaurantId.");
    }

    private static Capacity ReadCapacityOrFail()
    {
        Console.WriteLine("Available Capacity: (2, 4, 6):");
        Console.Write("Capacity: ");

        if (Enum.TryParse<Capacity>(Console.ReadLine(), true, out var Capacity))
            return Capacity;

        throw new ArgumentException($"Invalid Capacity. Please enter one of these: 2, 4, 6");
    }

    public async Task AddTableUI()
    {
        var capacity = ReadCapacityOrFail();
        var restaurantId = ReadRestaurantIdOrFail();

        try
        {
            await _service.AddTableAsync(capacity!, restaurantId!);
            Console.WriteLine("Table successfully created!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateTableCapacityUI()
    {
        try
        {
            var id = ReadIdOrFail();
            var capacity = ReadCapacityOrFail();

            await _service.UpdateTableCapacityAsync(id, capacity);
            Console.WriteLine("Table capacity was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateTableRestaurantUI()
    {
        try
        {
            var id = ReadIdOrFail();
            var restaurantId = ReadRestaurantIdOrFail();

            await _service.UpdateTableRestaurantAsync(id, restaurantId);
            Console.WriteLine("Table restaurant was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task DeleteTableUI()
    {
        try
        {
            var id = ReadIdOrFail();
            await _service.DeleteTableAsync(id);
            Console.WriteLine("Table was deleted successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task GetTableByIdUI()
    {
        try
        {
            var id = ReadIdOrFail();

            var table = await _service.GetTableByIdAsync(id);
            Console.WriteLine($"Employee Id: {table.TableId},\n   Capacity: {table.Capacity}," +
            $"\n    RestaurantId: {table.RestaurantId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task GetTablesUI()
    {
        var Tables = await _service.GetTablesAsync();
        foreach (var table in Tables)
        {
            Console.WriteLine($"Employee Id: {table.TableId},\n   Capacity: {table.Capacity}," +
             $"\n    RestaurantId: {table.RestaurantId}");
        }
    }
}
