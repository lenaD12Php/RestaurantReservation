using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly RestaurantReservationDbContext _context; 

    public CustomerRepository(RestaurantReservationDbContext context) => _context = context;
    
    public async Task AddCustomerAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    public async Task<Customer?> GetCustomerByIdAsync(int customerId)
    {
        return await _context.Customers.AsNoTracking().Include(c => c.Reservations).FirstOrDefaultAsync(c => c.CustomerId == customerId);
    }

    public async Task<List<Customer>> GetCustomersAsync()
    {
        return await _context.Customers.AsNoTracking().Include(c=>c.Reservations).ToListAsync();
    }

    public async Task<List<Customer>> GetCustomersWithReservationPartySizeAsync(int partySize)
    {
        return await _context.Customers.FromSqlRaw("CustomerWithGreaterPartySize {0}", partySize).AsNoTracking().ToListAsync(); 
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        var tracked = _context.Customers.Local
       .FirstOrDefault(c => c.CustomerId == customer.CustomerId);
        if (tracked != null)
            _context.Entry(tracked).State = EntityState.Detached;

        _context.Attach(customer);
        _context.Entry(customer).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCustomerAsync(Customer customer)
    {
        var entity = await _context.Customers.FindAsync(new object[] { customer.CustomerId });
        if (entity is null) return;

        _context.Customers.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
