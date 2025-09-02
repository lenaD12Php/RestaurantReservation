using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces;

public interface IOrderService
{
    Task<Order> GetOrderByIdAsync(int orderId);
    Task<List<Order>> GetOrdersAsync();
    Task<List<Order>> ListOrdersAndMenuItemsAsync(int reservationId);
    Task AddOrderAsync(DateTime orderDate, decimal totalAmount, int reservationId, int employeeId);
    Task DeleteOrderAsync(int orderId);
    Task UpdateOrderOrderDateAsync(int  orderId, DateTime orderDate);
    Task UpdateOrderTotalAmountAsync(int orderId, decimal totalAmount);
    Task UpdateOrderReservationAsync(int orderId, int reservationId);
    Task UpdateOrderEmployeeAsync(int orderId, int employeeId);
    Task<decimal> CalculateAverageOrderAmountAsync(int employeeId);
}
