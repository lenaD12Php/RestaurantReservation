using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Db.Validators;

namespace RestaurantReservation.Db.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository) => _repository = repository;

    public async Task AddCustomerAsync(string firstName, string lastName, string? email, string phoneNumber)
    {
        CustomerValidator.InputValidator(firstName, lastName, email, phoneNumber);

        var customer = new Customer
        {
            Firstname = firstName,
            Lastname = lastName,
            Email = email,
            PhoneNumber = phoneNumber
        };
       await  _repository.AddCustomerAsync(customer);
    }

    public async Task UpdateCustomerEmailAsync(int customerId, string email)
    {
        CustomerValidator.UpdateEmailInputValidator(email);

        var customer = await _repository.GetCustomerByIdAsync(customerId);
        CustomerValidator.CustomerNotFound(customer);

        customer.Email = email;
        await _repository.UpdateCustomerAsync(customer);
    }

    public async  Task UpdateCustomerFirstNameAsync(int customerId, string firstName)
    {
        CustomerValidator.UpdateNameInputValidator(firstName);

        var customer = await _repository.GetCustomerByIdAsync(customerId);
        CustomerValidator.CustomerNotFound(customer);

        customer.Firstname = firstName;
        await _repository.UpdateCustomerAsync(customer);
    }

    public async Task UpdateCustomerLastNameAsync(int customerId, string lastName)
    {
        CustomerValidator.UpdateLastNameInputValidator(lastName);

        var customer = await _repository.GetCustomerByIdAsync(customerId);
        CustomerValidator.CustomerNotFound(customer);

        customer.Lastname = lastName;
        await _repository.UpdateCustomerAsync(customer);
    }

    public async Task UpdateCustomerPhoneNumberAsync(int customerId, string phoneNumber)
    {
        CustomerValidator.UpdatePhoneInputValidator(phoneNumber);

        var customer = await _repository.GetCustomerByIdAsync(customerId);
        CustomerValidator.CustomerNotFound(customer);

        customer.PhoneNumber = phoneNumber;
        await _repository.UpdateCustomerAsync(customer);
    }

    public async Task DeleteCustomerAsync(int customerId)
    {
        var customer = await _repository.GetCustomerByIdAsync(customerId);
        CustomerValidator.CustomerNotFound(customer);

        await _repository.DeleteCustomerAsync(customer);
    }

    public async Task<Customer> GetCustomerByIdAsync(int customerId)
    {
        return await _repository.GetCustomerByIdAsync(customerId);
    }

    public async Task<List<Customer>> GetCustomersAsync()
    {
        return await _repository.GetCustomersAsync();
    }

    public async Task<List<Customer>> GetCustomersWithReservationPartySizeAsync(int partySize)
    {
        return await _repository.GetCustomersWithReservationPartySizeAsync(partySize);
    }
}

