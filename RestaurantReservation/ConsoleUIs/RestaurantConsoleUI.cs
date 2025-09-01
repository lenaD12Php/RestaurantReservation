using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.ConsoleUIs;

public class RestaurantConsoleUI
{
    private readonly IRestaurantService _service;
    public RestaurantConsoleUI(IRestaurantService service) => _service = service;

    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine("\n1) Add Restaurant  \n2) Update Name  \n3) Update Address  " +
                "\n4) Update OpeningHours  \n5) Update PhoneNumber  \n6) Delete Restaurant  " +
                "\n7) Get Restaurant  \n8) Get Restaurants  0) Exit");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    await AddRestaurantUI();
                    break;
                case "2":
                    await UpdateRestaurantNameUI();
                    break;
                case "3":
                    await UpdateRestaurantAddressUI();
                    break;
                case "4":
                    await UpdateRestaurantOpeningHoursUI();
                    break;
                case "5":
                    await UpdateRestaurantPhoneNumberUI();
                    break;
                case "6":
                    await DeleteRestaurantUI();
                    break;
                case "7":
                    await GetRestaurantByIdUI();
                    break;
                case "8":
                    await GetRestaurantsUI();
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
        Console.Write("CustomerId: ");
        return int.TryParse(Console.ReadLine(), out var id) ? id : throw new ArgumentException("Invalid id.");
    }

    public async Task AddRestaurantUI()
    {
        Console.WriteLine("Name: ");
        var name = Console.ReadLine();
        Console.WriteLine("Address: ");
        var address = Console.ReadLine();
        Console.WriteLine("PhoneNumber: ");
        var phoneNumber = Console.ReadLine();
        Console.WriteLine("OpeningHours: ");
        var openingHours = Console.ReadLine();

        try
        {
            await _service.AddRestaurantAsync(name!, address!, phoneNumber!, openingHours);
            Console.WriteLine("Restaurant successfully created!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateRestaurantNameUI()
    {
        try
        {
            var id = ReadIdOrFail();
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();
            await _service.UpdateRestaurantNameAsync(id, name);
            Console.WriteLine("Restaurant name was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateRestaurantAddressUI()
    {
        try
        {
            var id = ReadIdOrFail();
            Console.WriteLine("Address: ");
            var address = Console.ReadLine();
            await _service.UpdateRestaurantAddressAsync(id, address);
            Console.WriteLine("Restaurant address was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateRestaurantOpeningHoursUI()
    {
        try
        {
            var id = ReadIdOrFail();
            Console.WriteLine("OpeningHours: ");
            var openingHours = Console.ReadLine();
            await _service.UpdateRestaurantOpeningHoursAsync(id, openingHours);
            Console.WriteLine("Restaurant openingHours was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateRestaurantPhoneNumberUI()
    {
        try
        {
            var id = ReadIdOrFail();
            Console.WriteLine("PhoneNumber: ");
            var phone = Console.ReadLine();
            await _service.UpdateRestaurantPhoneNumberAsync(id, phone);
            Console.WriteLine("Restaurant phone was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task DeleteRestaurantUI()
    {
        try
        {
            var id = ReadIdOrFail();
            await _service.DeleteRestaurantAsync(id);
            Console.WriteLine("Restaurant was deleted successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task GetRestaurantByIdUI()
    {
        try
        {
            var id = ReadIdOrFail();
            var restaurant = await _service.GetRestaurantByIdAsync(id);
            Console.WriteLine($"Restaurant Id: {restaurant.RestaurantId},\n   Name: {restaurant.Name}," +
            $"\n    Address: {restaurant.Address},\n    OpeningHours: {restaurant.OpeningHours}, " +
            $"\n    PhoneNumber: {restaurant.PhoneNumber}");
            restaurant.Tables.ForEach(t => Console.WriteLine($"    TableId: {t.TableId},\n    Capacity: {t.Capacity}"));
            restaurant.Employees.ForEach(e => Console.WriteLine($"    EmployeeId: {e.EmployeeId},\n    EmployeeName: {e.Firstname} {e.Lastname}," +
                $"\n    Position: {e.Position}"));

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task GetRestaurantsUI()
    {
        var Restaurants = await _service.GetRestaurantsAsync();
        foreach (var restaurant in Restaurants)
        {
            Console.WriteLine($"Restaurant Id: {restaurant.RestaurantId},\n   Name: {restaurant.Name}," +
            $"\n    Address: {restaurant.Address},\n    OpeningHours: {restaurant.OpeningHours}, " +
            $"\n    PhoneNumber: {restaurant.PhoneNumber}");
            restaurant.Tables.ForEach(t => Console.WriteLine($"    TableId: {t.TableId},\n    Capacity: {t.Capacity}"));
            restaurant.Employees.ForEach(e => Console.WriteLine($"    EmployeeId: {e.EmployeeId},\n    EmployeeName: {e.Firstname} {e.Lastname}," +
                $"\n    Position: {e.Position}")); 
        }
    }
}





