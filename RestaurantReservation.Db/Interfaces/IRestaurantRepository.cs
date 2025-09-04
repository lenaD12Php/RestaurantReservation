using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces;

public interface IRestaurantRepository
{
    Task<Restaurant?> GetRestaurantByIdAsync(int restaurantId);
    Task<List<Restaurant>> GetRestaurantsAsync();
    Task AddRestaurantAsync(Restaurant restaurant);
    Task DeleteRestaurantAsync(Restaurant restaurant);
    Task UpdateRestaurantAsync(Restaurant restaurant);
    Task<decimal> GetTotalRevenueForRestaurantAsync(int restaurantId);
}
