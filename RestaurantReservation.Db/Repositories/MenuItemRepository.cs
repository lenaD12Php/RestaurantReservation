using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories;

public class MenuItemRepository : IMenuItemRepository
{
    private readonly RestaurantReservationDbContext _context;
    
    public MenuItemRepository (RestaurantReservationDbContext context) => _context = context;

    public async Task AddMenuItemAsync(MenuItem menuItem)
    {
        await _context.MenuItems.AddAsync(menuItem);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMenuItemAsync(MenuItem menuItem)
    {
        var entity = await _context.MenuItems.FindAsync(new object[] { menuItem.MenuItemId });
        if (entity is null) return;

        _context.MenuItems.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<MenuItem>> GetMenuItemsAsync()
    {
        return await _context.MenuItems.AsNoTracking().Include(mi => mi.OrderItems).ToListAsync();
    }

    public async Task<MenuItem?> GetMenuItemByIdAsync(int menuItemId)
    {
        return await _context.MenuItems.AsNoTracking().Include(mi => mi.OrderItems)
            .FirstOrDefaultAsync(mi => mi.MenuItemId == menuItemId);
    }

    public async Task UpdateMenuItemAsync(MenuItem menuItem)
    {
        var tracked = _context.MenuItems.Local
        .FirstOrDefault(mi => mi.MenuItemId == menuItem.MenuItemId);
        if (tracked != null)
            _context.Entry(tracked).State = EntityState.Detached;

        _context.Attach(menuItem);
        _context.Entry(menuItem).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
