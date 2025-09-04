using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Services;


public class ReservationService : IReservationService
{
    private readonly IReservationRepository _repository;

    public ReservationService(IReservationRepository repository) => _repository = repository;

    public async Task AddReservationAsync(DateTime reservationDate, int partySize, int restaurantId, int customerId, int tableId)
    {
        var reservation = new Reservation()
        { 
            ReservationDate = reservationDate,
            PartySize = partySize,
            RestaurantId = restaurantId,
            CustomerId = customerId,
            TableId = tableId
        };
        await _repository.AddReservationAsync(reservation);
    }

    public async Task DeleteReservationAsync(int reservationId)
    {
        var reservation = await _repository.GetReservationByIdAsync(reservationId);
        await _repository.DeleteReservationAsync(reservation);
    }

    public async Task<Reservation> GetReservationByIdAsync(int reservationId)
    {
       return await _repository.GetReservationByIdAsync(reservationId);
    }

    public async Task<List<Reservation>> GetReservationsAsync()
    {
        return await _repository.GetReservationsAsync();
    }

    public async Task<List<Reservation>> GetReservationsByCustomerAsync(int customerId)
    {
        return await _repository.GetReservationsByCustomerAsync(customerId);
    }

    public async Task UpdateReservationCustomerAsync(int reservationId, int customerId)
    {
        var reservation = await _repository.GetReservationByIdAsync(reservationId);
        reservation.CustomerId = customerId;

        await _repository.UpdateReservationAsync(reservation);

    }

    public async Task UpdateReservationDateAsync(int reservationId, DateTime reservationDate)
    {
        var reservation = await _repository.GetReservationByIdAsync(reservationId);
        reservation.ReservationDate = reservationDate;

        await _repository.UpdateReservationAsync(reservation);
    }

    public async Task UpdateReservationRestaurantAsync(int reservationId, int restaurantId)
    {
        var reservation = await _repository.GetReservationByIdAsync(reservationId);
        reservation.RestaurantId = restaurantId;

        await _repository.UpdateReservationAsync(reservation);
    }

    public async Task UpdateReservationSizeAsync(int reservationId, int partySize)
    {
        var reservation = await _repository.GetReservationByIdAsync(reservationId);
        reservation.PartySize = partySize;

        await _repository.UpdateReservationAsync(reservation);
    }

    public async Task UpdateReservationTableAsync(int reservationId, int tableId)
    {
        var reservation = await _repository.GetReservationByIdAsync(reservationId);
        reservation.TableId = tableId;

        await _repository.UpdateReservationAsync(reservation);
    }
}
