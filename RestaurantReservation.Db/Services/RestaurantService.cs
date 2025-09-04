using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces;
using System.Net;

namespace RestaurantReservation.Db.Services;

public class RestaurantService : IRestaurantService
{
    private readonly IRestaurantRepository _repository;
    
    public RestaurantService(IRestaurantRepository repository) => _repository = repository; 

    public async Task AddRestaurantAsync(string name, string address, string phoneNumber, string openingHours)
    {
        var restaurant = new Restaurant
        {
            Name = name,
            Address = address,
            PhoneNumber = phoneNumber,
            OpeningHours = openingHours
        }; 
        await _repository.AddRestaurantAsync(restaurant);
    }

    public async Task DeleteRestaurantAsync(int restaurantId)
    {
        var restaurant = await _repository.GetRestaurantByIdAsync(restaurantId);

        await _repository.DeleteRestaurantAsync(restaurant);
    }

    public async Task<Restaurant?> GetRestaurantByIdAsync(int restaurantId)
    {
        return await _repository.GetRestaurantByIdAsync(restaurantId);
    }

    public async Task<List<Restaurant>> GetRestaurantsAsync()
    {
        return await _repository.GetRestaurantsAsync();
    }

    public async Task UpdateRestaurantAddressAsync(int restaurantId, string address)
    {
        var restaurant = await _repository.GetRestaurantByIdAsync(restaurantId);
        restaurant.Address = address;

        await _repository.UpdateRestaurantAsync(restaurant);
    }

    public async Task UpdateRestaurantNameAsync(int restaurantId, string name)
    {
        var restaurant = await _repository.GetRestaurantByIdAsync(restaurantId);
        restaurant.Name = name;

        await _repository.UpdateRestaurantAsync(restaurant);
    }

    public async Task UpdateRestaurantOpeningHoursAsync(int restaurantId, string openingHours)
    {
        var restaurant = await _repository.GetRestaurantByIdAsync(restaurantId);
        restaurant.OpeningHours = openingHours;

        await _repository.UpdateRestaurantAsync(restaurant);
    }

    public async Task UpdateRestaurantPhoneNumberAsync(int restaurantId, string phoneNumber)
    {
        var restaurant = await _repository.GetRestaurantByIdAsync(restaurantId);
        restaurant.PhoneNumber = phoneNumber;

        await _repository.UpdateRestaurantAsync(restaurant);
    }

    public async Task<decimal> GetTotalRevenueForRestaurantAsync(int restaurantId)
    {
        return await _repository.GetTotalRevenueForRestaurantAsync(restaurantId);
    }
}
