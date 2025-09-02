using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Services;


public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository) => _repository = repository;

    public async Task AddOrderAsync(DateTime orderDate, decimal totalAmount, int reservationId, int employeeId)
    {
        var order = new Order
        {
            OrderDate = orderDate,
            TotalAmount = totalAmount,
            ReservationId = reservationId,
            EmployeeId = employeeId
        };

       await _repository.AddOrderAsync(order);
    }

    public async Task DeleteOrderAsync(int orderId)
    {
       var order = await GetOrderByIdAsync(orderId);

        await _repository.DeleteOrderAsync(order);
    }

    public async  Task<Order> GetOrderByIdAsync(int orderId)
    {
        return await _repository.GetOrderByIdAsync(orderId);
    }

    public async Task<List<Order>> GetOrdersAsync()
    {
        return await _repository.GetOrdersAsync();
    }

    public async Task<List<Order>> ListOrdersAndMenuItemsAsync(int reservationId)
    {
        return await _repository.ListOrdersAndMenuItemsAsync(reservationId);
    }

    public async Task UpdateOrderEmployeeAsync(int orderId, int employeeId)
    {
        var order = await GetOrderByIdAsync(orderId);
        order.EmployeeId = employeeId;

        await _repository.UpdateOrderAsync(order);
    }

    public async Task UpdateOrderOrderDateAsync(int orderId, DateTime orderDate)
    {
        var order = await GetOrderByIdAsync(orderId);
        order.OrderDate = orderDate;

        await _repository.UpdateOrderAsync(order);
    }

    public async Task UpdateOrderReservationAsync(int orderId, int reservationId)
    {
        var order = await GetOrderByIdAsync(orderId);
        order.ReservationId = reservationId;

        await _repository.UpdateOrderAsync(order);
    }

    public async Task UpdateOrderTotalAmountAsync(int orderId, decimal totalAmount)
    {
        var order = await _repository.GetOrderByIdAsync(orderId);
        order.TotalAmount = totalAmount;

        await _repository.UpdateOrderAsync(order);
    }
}
