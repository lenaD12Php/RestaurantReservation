using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces;

public interface IOrderRepository
{
    Task<Order?> GetOrderByIdAsync(int orderId);
    Task<List<Order>> GetOrdersAsync();
    Task<List<Order>> ListOrdersAndMenuItemsAsync(int reservationId);
    Task AddOrderAsync(Order order);
    Task DeleteOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
    Task<decimal> CalculateAverageOrderAmountAsync(int employeeId);
}
