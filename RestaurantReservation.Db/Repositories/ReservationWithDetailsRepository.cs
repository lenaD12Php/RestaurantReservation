using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories;

public class ReservationWithDetailsRepository : IReservationWithDetailsRepository
{
    private readonly RestaurantReservationDbContext _context;

    public ReservationWithDetailsRepository(RestaurantReservationDbContext context) => _context = context;
    

    public async Task<List<CustomerAndRestaurantByReservation>> GetReservationsWithCustomerAndRestaurantDetailsAsync()
    {
        return await _context.ReservationsWithCustomerAndRestaurantDetails.AsNoTracking().ToListAsync();
    }
}
