using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces;

public interface ICustomerRepository
{
    Task AddCustomerAsync(Customer customer);
    Task<Customer?> GetCustomerByIdAsync(int customerId);
    Task<List<Customer>> GetCustomersAsync();
    Task<List<Customer>> GetCustomersWithReservationPartySizeAsync(int partySize);
    Task UpdateCustomerAsync(Customer customer);
    Task DeleteCustomerAsync(Customer customer);
}