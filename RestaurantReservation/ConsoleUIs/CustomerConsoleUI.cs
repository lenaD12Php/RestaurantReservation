using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.ConsoleUIs;

public class CustomerConsoleUI
{
    private readonly ICustomerService _service;
    public CustomerConsoleUI(ICustomerService service) => _service = service;

    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine("\n1) Add Customer  \n2) Update FirstName  " +
                "\n3) Update LastName  \n4) Update Email  \n5) Update PhoneNumber  " +
                "\n6) Delete Customer  \n7) Get Customer  \n8) Get Customers  \n0) Exit");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1": 
                    await AddCustomerUI(); 
                    break;
                case "2": 
                    await UpdateCustomerFirstNameUI(); 
                    break;
                case "3": 
                    await UpdateCustomerLastNameUI(); 
                    break;
                case "4": 
                    await UpdateCustomerEmailUI(); 
                    break;
                case "5": 
                    await UpdateCustomerPhoneNumberUI(); 
                    break;
                case "6": 
                    await DeleteCustomerUI(); 
                    break;
                case "7": 
                    await GetCustomerByIdUI(); 
                   break;
                case "8":
                    await GetCustomersUI(); 
                    break;
                case "0": 
                    return;
                default: 
                    Console.WriteLine("Pick a valid option."); 
                    break;
            }
        }
    }

    private static int ReadIdOrFail()
    {
        Console.Write("CustomerId: ");
        return int.TryParse(Console.ReadLine(), out var id) ? id : throw new ArgumentException("Invalid id.");
    }

    public async Task AddCustomerUI()
    {
        Console.WriteLine("FirstName: ");
        var firstname = Console.ReadLine();
        Console.WriteLine("LastName: ");
        var lastname = Console.ReadLine();
        Console.WriteLine("Email: ");
        var email = Console.ReadLine();
        Console.WriteLine("PhoneNumber: ");
        var phoneNumber = Console.ReadLine();

        try
        {
            await _service.AddCustomerAsync(firstname!, lastname!, email, phoneNumber!);
            Console.WriteLine("Customer successfully created!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    public async Task UpdateCustomerFirstNameUI()
    {
        try
        {
            var id = ReadIdOrFail();
            Console.WriteLine("FirstName: ");
            var firstname = Console.ReadLine();
            await _service.UpdateCustomerFirstNameAsync(id, firstname);
            Console.WriteLine("Customer firstname was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateCustomerLastNameUI()
    {
        try
        {
            var id = ReadIdOrFail();
            Console.WriteLine("LastName: ");
            var lastname = Console.ReadLine();
            await _service.UpdateCustomerLastNameAsync(id, lastname);
            Console.WriteLine("Customer lasstname was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateCustomerEmailUI()
    {
        try
        {
            var id = ReadIdOrFail();
            Console.WriteLine("Email: ");
            var email = Console.ReadLine();
            await _service.UpdateCustomerEmailAsync(id, email);
            Console.WriteLine("Customer email was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateCustomerPhoneNumberUI()
    {
        try
        {
            var id = ReadIdOrFail();
            Console.WriteLine("PhoneNumber: ");
            var phone = Console.ReadLine();
            await _service.UpdateCustomerPhoneNumberAsync(id, phone);
            Console.WriteLine("Customer phone was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task DeleteCustomerUI()
    {
        try
        {
            var id = ReadIdOrFail();
            await _service.DeleteCustomerAsync(id);
            Console.WriteLine("Customer was deleted successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task GetCustomerByIdUI()
    {
        try
        {
            var id = ReadIdOrFail();
            var customer = await _service.GetCustomerByIdAsync(id);
            Console.WriteLine($"Customer Id: {customer.CustomerId},\n   FirstName: {customer.Firstname}," +
            $"\n    LastName: {customer.Lastname},\n    Email: {customer.Email}, " +
            $"\n    PhoneNumber: {customer.PhoneNumber}");
            customer.Reservations.ForEach(r => Console.WriteLine($"    Reservation date: {r.ReservationDate}"));
        }
        catch (Exception ex) 
        { 
            Console.WriteLine($"Error: {ex.Message}"); 
        }
    }

    public async Task GetCustomersUI()
    {
        var customers = await _service.GetCustomersAsync();
        foreach (var customer in customers)
        {
            Console.WriteLine($"Customer Id: {customer.CustomerId},\n   FirstName: {customer.Firstname}," +
            $"\n    LastName: {customer.Lastname},\n    Email: {customer.Email}, " +
            $"\n    PhoneNumber: {customer.PhoneNumber}");
            customer.Reservations.ForEach(r => Console.WriteLine($"    Reservation date: {r.ReservationDate}"));
        }
    }
}


    


