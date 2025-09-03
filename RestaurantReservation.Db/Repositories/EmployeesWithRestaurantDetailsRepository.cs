using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories;

public class EmployeesWithRestaurantDetailsRepository : IEmployeesWithRestaurantDetailsRepository
{
    private readonly RestaurantReservationDbContext _context;

    public EmployeesWithRestaurantDetailsRepository(RestaurantReservationDbContext context) => _context = context;

    public async Task<List<EmployeesWithRestaurantDetails>> GetEmployeesWithRestaurantDetailsAsync ()
    {
        return await _context.EmployeesWithRestaurantDetails.AsNoTracking().ToListAsync();
    }
}
