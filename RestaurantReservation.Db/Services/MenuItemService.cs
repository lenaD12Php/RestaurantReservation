using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Services;


public class MenuItemService : IMenuItemService
{
    private readonly IMenuItemRepository _repository;

    public MenuItemService(IMenuItemRepository repository) => _repository = repository;

    public async Task AddMenuItemAsync(string name, string description, decimal price, int restaurantId)
    {
        var menuItem = new MenuItem
        {
            Name = name,
            Description = description,
            Price = price,
            RestaurantId = restaurantId
        };

        await _repository.AddMenuItemAsync(menuItem);
    }

    public async Task DeleteMenuItemAsync(int menuItemId)
    {
        var menuItem = await GetMenuItemByIdAsync(menuItemId);

        await _repository.DeleteMenuItemAsync(menuItem);
    }

    public async Task<List<MenuItem>> GetMenuItemsAsync()
    {
        return await _repository.GetMenuItemsAsync();
    }

    public async Task<MenuItem> GetMenuItemByIdAsync(int menuItemId)
    {
        return await _repository.GetMenuItemByIdAsync(menuItemId);
    }

    public async Task UpdateMenuItemDescriptionAsync(int menuItemId, string description)
    {
        var menuItem = await _repository.GetMenuItemByIdAsync(menuItemId);
        menuItem.Description = description;

        await _repository.UpdateMenuItemAsync(menuItem);
    }

    public async Task UpdateMenuItemNameAsync(int menuItemId, string name)
    {
        var menuItem = await _repository.GetMenuItemByIdAsync(menuItemId);
        menuItem.Name = name;
        await _repository.UpdateMenuItemAsync(menuItem);
    }

    public async Task UpdateMenuItemPriceAsync(int menuItemId, decimal price)
    {
        var menuItem = await _repository.GetMenuItemByIdAsync(menuItemId);
        menuItem.Price = price;

        await _repository.UpdateMenuItemAsync(menuItem);
    }

    public async Task UpdateMenuItemRestaurantAsync(int menuItemId, int restaurantId)
    {
        var menuItem = await _repository.GetMenuItemByIdAsync(menuItemId);
         menuItem.RestaurantId = restaurantId;

        await _repository.UpdateMenuItemAsync(menuItem);
    }
}
