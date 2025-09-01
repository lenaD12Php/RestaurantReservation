using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces;
public interface IReservationService
{
    Task<Reservation> GetReservationByIdAsync(int reservationId);
    Task<List<Reservation>> GetReservationsAsync();
    Task AddReservationAsync(DateTime reservationDate, int partySize, int restaurantId, int customerId, int tableId);
    Task DeleteReservationAsync(int reservationId);
    Task UpdateReservationDateAsync(int reservationId, DateTime reservationDate);
    Task UpdateReservationSizeAsync(int reservationId, int partySize);
    Task UpdateReservationRestaurantAsync(int reservationId, int restaurantId);
    Task UpdateReservationCustomerAsync(int reservationId, int customerId);
    Task UpdateReservationTableAsync(int reservationId, int tableId);
}
