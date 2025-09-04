using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly RestaurantReservationDbContext _context;
    public RestaurantRepository(RestaurantReservationDbContext context) => _context = context;

    public async Task AddRestaurantAsync(Restaurant restaurant)
    {
        await _context.Restaurants.AddAsync(restaurant);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRestaurantAsync(Restaurant restaurant)
    {
        var entity = await _context.Restaurants.FindAsync(new object[] { restaurant.RestaurantId });
        if (entity is null) return;

        _context.Restaurants.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Restaurant?> GetRestaurantByIdAsync(int restaurantId)
    {
        return await _context.Restaurants.AsNoTracking().Include(r => r.Tables)
            .Include(r => r.Reservations).Include(r => r.Employees).Include(r => r.MenuItems)
            .FirstOrDefaultAsync(r => r.RestaurantId == restaurantId);
    }

    public async Task<List<Restaurant>> GetRestaurantsAsync()
    {
        return await _context.Restaurants.AsNoTracking().Include(r => r.Tables)
           .Include(r => r.Reservations).Include(r => r.Employees).Include(r => r.MenuItems)
           .ToListAsync();
    }

    public async Task UpdateRestaurantAsync(Restaurant restaurant)
    {
        var tracked = _context.Restaurants.Local
        .FirstOrDefault(r => r.RestaurantId == restaurant.RestaurantId);
        if (tracked != null)
            _context.Entry(tracked).State = EntityState.Detached;

        _context.Attach(restaurant);
        _context.Entry(restaurant).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<decimal> GetTotalRevenueForRestaurantAsync(int restaurantId)
    {
        var sql = "SELECT dbo.fn_TotalRevenueForRestaurant(@restaurantId) AS Value";

        var total = await _context.Database.SqlQueryRaw<decimal>(
            sql,
            new SqlParameter("@restaurantId", restaurantId)
        ).FirstAsync();

        return total;
    }
}
