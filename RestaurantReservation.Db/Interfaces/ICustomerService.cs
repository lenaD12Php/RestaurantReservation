using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces;


public interface ICustomerService
{
    Task AddCustomerAsync(string firstName, string lastName, string? email, string phoneNumber);
    Task UpdateCustomerFirstNameAsync(int customerId, string firstName);
    Task UpdateCustomerLastNameAsync(int customerId, string lastName);
    Task UpdateCustomerEmailAsync(int customerId, string email);
    Task UpdateCustomerPhoneNumberAsync(int customerId, string phoneNumber);
    Task<Customer> GetCustomerByIdAsync(int customerId);
    Task<List<Customer>> GetCustomersAsync();
    Task<List<Customer>> GetCustomersWithReservationPartySizeAsync(int partySize);
    Task DeleteCustomerAsync(int customerId);
}
