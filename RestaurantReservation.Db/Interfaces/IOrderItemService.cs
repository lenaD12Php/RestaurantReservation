using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces;
public interface IOrderItemService
{
    Task<OrderItem> GetOrderItemByIdAsync(int orderItemId);
    Task<List<OrderItem>> GetOrderItemsAsync();
    Task AddOrderItemAsync(int orderId, int menuItemId, int quantity);
    Task DeleteOrderItemAsync(int orderItemId);
    Task UpdateOrderItemOrderAsync(int orderItemId, int orderId);
    Task UpdateOrderItemItemAsync(int orderItemId, int menuItemId);
    Task UpdateOrderItemQuantityAsync(int orderItemId, int quantity);
}
