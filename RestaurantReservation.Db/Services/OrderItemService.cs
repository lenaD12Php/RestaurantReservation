using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Services;


public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _repository;

    public OrderItemService(IOrderItemRepository repository) => _repository = repository;

    public async Task AddOrderItemAsync(int orderId, int menuItemId, int quantity)
    {
        var orderItem = new OrderItem()
        { 
            OrderId = orderId,
            MenuItemId = menuItemId,
            Quantity = quantity
        };
        await _repository.AddOrderItemAsync(orderItem);
    }

    public async Task DeleteOrderItemAsync(int orderItemId)
    {
        var orderItem = await _repository.GetOrderItemByIdAsync(orderItemId);
        await _repository.DeleteOrderItemAsync(orderItem);
    }

    public async Task<OrderItem> GetOrderItemByIdAsync(int orderItemId)
    {
        return await _repository.GetOrderItemByIdAsync(orderItemId);
    }

    public async Task<List<OrderItem>> GetOrderItemsAsync()
    {
        return await _repository.GetOrderItemsAsync();
    }

    public async Task UpdateOrderItemItemAsync(int orderItemId, int menuItemId)
    {
        var orderItem = await _repository.GetOrderItemByIdAsync(orderItemId);
        orderItem.MenuItemId = menuItemId;

        await _repository.UpdateOrderItemAsync(orderItem);
    }

    public async Task UpdateOrderItemOrderAsync(int orderItemId, int orderId)
    {
        var orderItem = await _repository.GetOrderItemByIdAsync(orderItemId);
        orderItem.OrderId = orderId;

        await _repository.UpdateOrderItemAsync(orderItem);
    }

    public async Task UpdateOrderItemQuantityAsync(int orderItemId, int quantity)
    {
        var orderItem = await _repository.GetOrderItemByIdAsync(orderItemId);
        orderItem.Quantity = quantity;

        await _repository.UpdateOrderItemAsync(orderItem);
    }
}
