using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly RestaurantReservationDbContext _context;
    public ReservationRepository(RestaurantReservationDbContext context) => _context = context;

    public async Task AddReservationAsync(Reservation reservation)
    {
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteReservationAsync(Reservation reservation)
    {
        var entity = await _context.Reservations.FindAsync(new object[] { reservation.ReservationId });
        if (entity is null) return;

        _context.Reservations.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Reservation?> GetReservationByIdAsync(int reservationId)
    {
        return await _context.Reservations.AsNoTracking().Include(r => r.orders)
            .FirstOrDefaultAsync(r=> r.ReservationId == reservationId);
    }

    public async Task<List<Reservation>> GetReservationsAsync()
    {
        return await _context.Reservations.AsNoTracking().Include(r => r.orders).ToListAsync();
    }

    public async Task UpdateReservationAsync(Reservation reservation)
    {
        var tracked = _context.Reservations.Local
        .FirstOrDefault(r => r.ReservationId == reservation.ReservationId);
        if (tracked != null)
            _context.Entry(tracked).State = EntityState.Detached;

        _context.Attach(reservation);
        _context.Entry(reservation).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
