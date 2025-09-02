using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly RestaurantReservationDbContext _context;
    public OrderRepository(RestaurantReservationDbContext context) => _context = context;

    public async Task AddOrderAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteOrderAsync(Order order)
    {
        var entity = await _context.Orders.FindAsync(new object[] { order.OrderId });
        if (entity is null) return;

        _context.Orders.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Order?> GetOrderByIdAsync(int orderId)
    {
        return await _context.Orders.AsNoTracking().Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.OrderId == orderId);
    }

    public async Task<List<Order>> GetOrdersAsync()
    {
        return await _context.Orders.AsNoTracking().Include(o => o.OrderItems)
           .ToListAsync();
    }

    public async Task<List<Order>> ListOrdersAndMenuItemsAsync(int reservationId)
    {
        return await _context.Orders
            .Where(o => o.ReservationId == reservationId)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
            .AsNoTracking()
            .OrderBy(o => o.OrderDate)
            .ToListAsync();
    }

    public async Task UpdateOrderAsync(Order order)
    {
        var tracked = _context.Orders.Local
        .FirstOrDefault(o => o.OrderId == order.OrderId);
        if (tracked != null)
            _context.Entry(tracked).State = EntityState.Detached;

        _context.Attach(order);
        _context.Entry(order).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<decimal> CalculateAverageOrderAmountAsync(int employeeId)
    {
        return await _context.Orders.AsNoTracking().Where(o=> o.EmployeeId == employeeId)
            .AverageAsync(o => o.TotalAmount);
    }
}
