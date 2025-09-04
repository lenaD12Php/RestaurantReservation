using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces;

public interface IReservationWithDetailsService
{
    Task<List<CustomerAndRestaurantByReservation>> GetReservationsWithCustomerAndRestaurantDetailsAsync();
}
