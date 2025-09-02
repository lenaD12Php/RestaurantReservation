using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces;

public interface IMenuItemService
{
    Task AddMenuItemAsync(string name, string description, decimal price, int restaurantId);
    Task<MenuItem> GetMenuItemByIdAsync(int menuItemId);
    Task<List<MenuItem>> GetMenuItemsAsync();
    Task<List<MenuItem>> ListOrderedMenuItems(int reservationId);
    Task UpdateMenuItemNameAsync(int menuItemId, string name);
    Task UpdateMenuItemDescriptionAsync(int menuItemId, string description);
    Task UpdateMenuItemPriceAsync(int menuItemId, decimal price);
    Task UpdateMenuItemRestaurantAsync(int menuItemId, int restaurantId);
    Task DeleteMenuItemAsync(int menuItemId);
}
