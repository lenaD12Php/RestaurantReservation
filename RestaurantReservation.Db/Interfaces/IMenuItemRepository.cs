using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces;

public interface IMenuItemRepository
{
    Task AddMenuItemAsync(MenuItem menuItem);
    Task<MenuItem?> GetMenuItemByIdAsync(int MenuItemId);
    Task<List<MenuItem>> GetMenuItemsAsync();
    Task<List<MenuItem>> ListOrderedMenuItemsAsync(int reservationId);
    Task UpdateMenuItemAsync(MenuItem menuItem);
    Task DeleteMenuItemAsync(MenuItem menuItem);
}
