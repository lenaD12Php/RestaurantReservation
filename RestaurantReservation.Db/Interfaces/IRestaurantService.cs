using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces;

public interface IRestaurantService
{
    Task<Restaurant?> GetRestaurantByIdAsync(int restaurantId);
    Task<List<Restaurant>> GetRestaurantsAsync();
    Task AddRestaurantAsync(string name, string address, string phoneNumber, string openingHours);
    Task DeleteRestaurantAsync(int restaurantId);
    Task UpdateRestaurantNameAsync(int restaurantId, string name);
    Task UpdateRestaurantAddressAsync(int restaurantId, string address);
    Task UpdateRestaurantPhoneNumberAsync(int restaurantId, string phoneNumber);
    Task UpdateRestaurantOpeningHoursAsync(int restaurantId, string openingHours);
}

