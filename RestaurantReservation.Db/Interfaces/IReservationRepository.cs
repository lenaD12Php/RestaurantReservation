using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces;

public interface IReservationRepository
{
    Task <Reservation?> GetReservationByIdAsync (int  reservationId);
    Task<List<Reservation>> GetReservationsAsync ();
    Task AddReservationAsync(Reservation reservation);
    Task DeleteReservationAsync (Reservation reservation);
    Task UpdateReservationAsync (Reservation reservation);
}
