using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces;

public interface IOrderItemRepository
{
    Task<OrderItem?> GetOrderItemByIdAsync(int orderItemId);
    Task<List<OrderItem>> GetOrderItemsAsync();
    Task AddOrderItemAsync(OrderItem orderItem);
    Task DeleteOrderItemAsync(OrderItem orderItem);
    Task UpdateOrderItemAsync(OrderItem orderItem);
}
