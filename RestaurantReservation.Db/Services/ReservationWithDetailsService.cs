using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services;

public class ReservationWithDetailsService : IReservationWithDetailsService
{
    private readonly IReservationWithDetailsRepository _repository;

    public ReservationWithDetailsService(IReservationWithDetailsRepository repository) => _repository = repository;
    
    public async  Task<List<CustomerAndRestaurantByReservation>> GetReservationsWithCustomerAndRestaurantDetailsAsync()
    {
        return await _repository.GetReservationsWithCustomerAndRestaurantDetailsAsync();
    }
}

