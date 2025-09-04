using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.ConsoleUIs;

public class MenuItemConsoleUI
{
    private readonly IMenuItemService _service;
    public MenuItemConsoleUI(IMenuItemService service) => _service = service;

    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine("\n1) Add MenuItem  \n2) Update Name  \n3) Update Descrioption  " +
                "\n4) Update Price  \n5) Update Restaurant  \n6) Delete MenuItem  " +
                "\n7) Get MenuItem  \n8) Get MenuItems  \n9) List Ordered MenuItems By Reservation  \n0) Exit");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1": 
                    await AddMenuItemUI(); 
                    break;
                case "2": 
                    await UpdateMenuItemNameUI(); 
                    break;
                case "3": 
                    await UpdateMenuItemDescriptionUI(); 
                    break;
                case "4": 
                    await UpdateMenuItemPriceUI(); 
                    break;
                case "5": 
                    await UpdateMenuItemRestaurantUI(); 
                    break;
                case "6": 
                    await DeleteMenuItemUI(); 
                    break;
                case "7": 
                    await GetMenuItemByIdUI(); 
                    break;
                case "8": 
                    await GetMenuItemsUI(); 
                    break;
                case "9":
                    await ListOrderedMenuItemsByReservationUI();
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
        Console.Write("MenuItemId: ");
        return int.TryParse(Console.ReadLine(), out var id) ? id : throw new ArgumentException("Invalid id.");
    }

    private static decimal ReadPriceOrFail()
    {
        Console.Write("Prcie: ");
        return decimal.TryParse(Console.ReadLine(), out var price) ? price : throw new ArgumentException("Invalid price.");
    }

    private static int ReadRestaurantIdOrFail()
    {
        Console.Write("RestaurantId: ");
        return int.TryParse(Console.ReadLine(), out var restaurantId) ? restaurantId : throw new ArgumentException("Invalid restaurantId.");
    }

    private static int ReadReservationIdOrFail()
    {
        Console.Write("ReservationId: ");
        return int.TryParse(Console.ReadLine(), out var reservationId) ? reservationId : throw new ArgumentException("Invalid reservationId.");
    }

    public async Task AddMenuItemUI()
    {
        Console.WriteLine("Name: ");
        var name = Console.ReadLine();
        Console.WriteLine("Description: ");
        var description = Console.ReadLine();
        var price = ReadPriceOrFail();
        var restaurantId = ReadRestaurantIdOrFail();

        try
        {
            await _service.AddMenuItemAsync(name!, description!, price!, restaurantId!);
            Console.WriteLine("MenuItem successfully created!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateMenuItemNameUI()
    {
        try
        {
            var id = ReadIdOrFail();
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();
            await _service.UpdateMenuItemNameAsync(id, name);
            Console.WriteLine("MenuItem name was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateMenuItemDescriptionUI()
    {
        try
        {
            var id = ReadIdOrFail();
            Console.WriteLine("Description: ");
            var decription = Console.ReadLine();
            await _service.UpdateMenuItemDescriptionAsync(id, decription);
            Console.WriteLine("MenuItem description was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateMenuItemPriceUI()
    {
        try
        {
            var id = ReadIdOrFail();
            var price = ReadPriceOrFail();
            await _service.UpdateMenuItemPriceAsync(id, price);
            Console.WriteLine("MenuItem price was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateMenuItemRestaurantUI()
    {
        try
        {
            var id = ReadIdOrFail();
            var restaurantId = ReadRestaurantIdOrFail();
            await _service.UpdateMenuItemRestaurantAsync(id, restaurantId);
            Console.WriteLine("MenuItem restaurant was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task DeleteMenuItemUI()
    {
        try
        {
            var id = ReadIdOrFail();
            await _service.DeleteMenuItemAsync(id);
            Console.WriteLine("MenuItem was deleted successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task GetMenuItemByIdUI()
    {
        try
        {
            var id = ReadIdOrFail();

            var menuItem = await _service.GetMenuItemByIdAsync(id);
            Console.WriteLine($"MenuItem Id: {menuItem.MenuItemId},\n   Name: {menuItem.Name}," +
            $"\n    Description: {menuItem.Description},\n    Price: {menuItem.Price}, " +
            $"\n    RestaurantId: {menuItem.RestaurantId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task GetMenuItemsUI()
    {
        var menuItems = await _service.GetMenuItemsAsync();
        foreach (var menuItem in menuItems)
        {
            Console.WriteLine($"MenuItem Id: {menuItem.MenuItemId},\n   Name: {menuItem.Name}," +
            $"\n    Description: {menuItem.Description},\n    Price: {menuItem.Price}, " +
            $"\n    RestaurantId: {menuItem.RestaurantId}");
        }
    }

    public async Task ListOrderedMenuItemsByReservationUI()
    {
        var reservationId = ReadReservationIdOrFail();
        var menuItemsOrdered = await _service.ListOrderedMenuItemsAsync(reservationId);

        foreach (var menuItem in menuItemsOrdered)
        {
           menuItem.OrderItems.ForEach(oi => Console.WriteLine($"ReservationId:    {oi.Order.ReservationId}"));
           Console.WriteLine($"MenuItem Id: {menuItem.MenuItemId},\n   Name: {menuItem.Name}," +
           $"\n    Description: {menuItem.Description},\n    Price: {menuItem.Price}, " +
           $"\n    RestaurantId: {menuItem.RestaurantId}");
           
        }
    }
}
