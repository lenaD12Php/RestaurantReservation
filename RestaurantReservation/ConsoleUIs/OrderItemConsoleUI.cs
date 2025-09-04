using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.ConsoleUIs;

public class OrderItemConsoleUI
{
    private readonly IOrderItemService _service;
    public OrderItemConsoleUI(IOrderItemService service) => _service = service;

    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine("\n1) Add OrderItem  \n2) Update OrderId  \n3) Update MenuItemId  " +
                "\n4) Update Quantity  \n5) Delete OrderItem  \n6) Get OrderItem  " +
                "\n7) Get OrderItems  \n0) Exit");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    await AddOrderItemUI();
                    break;
                case "2":
                    await UpdateOrderItemOrderUI();
                    break;
                case "3":
                    await UpdateOrderItemMenuItemUI();
                    break;
                case "4":
                    await UpdateOrderItemQuantityUI();
                    break;
                case "5":
                    await DeleteOrderItemUI();
                    break;
                case "6":
                    await GetOrderItemByIdUI();
                    break;
                case "7":
                    await GetOrderItemsUI();
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
        Console.Write("OrderItemId: ");
        return int.TryParse(Console.ReadLine(), out var id) ? id : throw new ArgumentException("Invalid id.");
    }

    private static int ReadMenuItemIdOrFail()
    {
        Console.Write("MenuItemId: ");
        return int.TryParse(Console.ReadLine(), out var menuItemId) ? menuItemId : throw new ArgumentException("Invalid menuItemId.");
    }

    private static int ReadOrderIdOrFail()
    {
        Console.Write("OrderId: ");
        return int.TryParse(Console.ReadLine(), out var orderId) ? orderId : throw new ArgumentException("Invalid orderId.");
    }

    private static int ReadQuantityOrFail()
    {
        Console.Write("Quantity: ");
        return int.TryParse(Console.ReadLine(), out var quantity) ? quantity : throw new ArgumentException("Invalid quantity.");
    }

    public async Task AddOrderItemUI()
    {
        var orderId = ReadOrderIdOrFail();
        var menuItemId = ReadMenuItemIdOrFail();
        var quantity = ReadQuantityOrFail();
       
        try
        {
            await _service.AddOrderItemAsync(orderId!, menuItemId!, quantity!);
            Console.WriteLine("OrderItem successfully created!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateOrderItemOrderUI()
    {
        try
        {
            var id = ReadIdOrFail();
            var orderId = ReadOrderIdOrFail();

            await _service.UpdateOrderItemOrderAsync(id, orderId);
            Console.WriteLine("OrderItem orderItem was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateOrderItemMenuItemUI()
    {
        try
        {
            var id = ReadIdOrFail();
            var menuItemId = ReadMenuItemIdOrFail();

            await _service.UpdateOrderItemItemAsync(id, menuItemId);
            Console.WriteLine("OrderItem Item was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateOrderItemQuantityUI()
    {
        try
        {
            var id = ReadIdOrFail();
            var quantity = ReadQuantityOrFail();
           
            await _service.UpdateOrderItemQuantityAsync(id, quantity);
            Console.WriteLine("OrderItem Quantity was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task DeleteOrderItemUI()
    {
        try
        {
            var id = ReadIdOrFail();
            await _service.DeleteOrderItemAsync(id);
            Console.WriteLine("OrderItem was deleted successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task GetOrderItemByIdUI()
    {
        try
        {
            var id = ReadIdOrFail();

            var orderItem = await _service.GetOrderItemByIdAsync(id);
            Console.WriteLine($"OrderItemId: {orderItem.OrderItemId},\n   OrderId: {orderItem.OrderId}, " +
            $"\n    ItemId: {orderItem.MenuItemId},\n    Quantity: {orderItem.Quantity}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task GetOrderItemsUI()
    {
        var orderItems = await _service.GetOrderItemsAsync();
        foreach (var orderItem in orderItems)
        {
            Console.WriteLine($"OrderItemId: {orderItem.OrderItemId},\n   OrderId: {orderItem.OrderId}, " +
            $"\n    ItemId: {orderItem.MenuItemId},\n    Quantity: {orderItem.Quantity}");
        }
    }
}

