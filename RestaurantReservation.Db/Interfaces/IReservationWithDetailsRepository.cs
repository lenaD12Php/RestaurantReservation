using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces;

public interface IReservationWithDetailsRepository
{
    Task<List<CustomerAndRestaurantByReservation>> GetReservationsWithCustomerAndRestaurantDetailsAsync();
}
