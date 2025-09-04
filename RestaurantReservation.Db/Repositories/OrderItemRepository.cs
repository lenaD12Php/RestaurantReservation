using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly RestaurantReservationDbContext _context;

    public OrderItemRepository(RestaurantReservationDbContext context) => _context = context;

    public async Task AddOrderItemAsync(OrderItem orderItem)
    {
        await _context.OrderItems.AddAsync(orderItem);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteOrderItemAsync(OrderItem orderItem)
    {
        var entity = await _context.OrderItems.FindAsync(new object[] { orderItem.OrderItemId });
        if (entity is null) return;

        _context.OrderItems.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<OrderItem?> GetOrderItemByIdAsync(int orderItemId)
    {
        return await _context.OrderItems.AsNoTracking().FirstOrDefaultAsync(oi => oi.OrderItemId == orderItemId);
    }

    public async Task<List<OrderItem>> GetOrderItemsAsync()
    {
        return await _context.OrderItems.AsNoTracking().ToListAsync();
    }

    public async Task UpdateOrderItemAsync(OrderItem orderItem)
    {
        var tracked = _context.OrderItems.Local
        .FirstOrDefault(oi => oi.OrderItemId == orderItem.OrderItemId);
        if (tracked != null)
            _context.Entry(tracked).State = EntityState.Detached;

        _context.Attach(orderItem);
        _context.Entry(orderItem).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
