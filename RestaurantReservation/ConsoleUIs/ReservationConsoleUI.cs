using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.ConsoleUIs;

public class ReservationConsoleUI
{
    private readonly IReservationService _service;
    public ReservationConsoleUI(IReservationService service) => _service = service;

    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine("\n1) Add Reservation  \n2) Update ReservationDate  " +
                "\n3) Update PartySize  \n4) Update Restaurant  \n5) Update Customer  " +
                "\n6) Update Table  \n7) Delete Reservation  \n8) Get Reservation  " +
                "\n9) Get Reservations  \n0) Exit");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    await AddReservationUI();
                    break;
                case "2":
                    await UpdateReservationReservationDateUI();
                    break;
                case "3":
                    await UpdateReservationPartySizeUI();
                    break;
                case "4":
                    await UpdateReservationRestaurantUI();
                    break;
                case "5":
                    await UpdateReservationCustomerUI();
                    break;
                case "6":
                    await UpdateReservationTableUI();
                    break;
                case "7":
                    await DeleteReservation();
                    break;
                case "8":
                    await GetReservationUI();
                    break;
                case "9":
                    await GetReservationsUI();
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
        Console.Write("OrderId: ");
        return int.TryParse(Console.ReadLine(), out var id) ? id : throw new ArgumentException("Invalid id.");
    }
    private static DateTime ReadReservationDateOrFail()
    {
        Console.Write("ReservationDate(yyyy-MM-dd HH:mm:ss): ");
        return DateTime.TryParse(Console.ReadLine(), out var reservationDate) ? reservationDate : throw new ArgumentException("Invalid reservationDate.");
    }

    private static int ReadPartySizeOrFail()
    {
        Console.Write("PartySize: ");
        return int.TryParse(Console.ReadLine(), out var partySize) ? partySize : throw new ArgumentException("Invalid partySize.");
    }

    private static int ReadRestaurantIdOrFail()
    {
        Console.Write("RestaurantId: ");
        return int.TryParse(Console.ReadLine(), out var restaurantId) ? restaurantId : throw new ArgumentException("Invalid restaurantId.");
    }

    private static int ReadCustomerIdOrFail()
    {
        Console.Write("CustomerId: ");
        return int.TryParse(Console.ReadLine(), out var customerId) ? customerId : throw new ArgumentException("Invalid customerId.");
    }

    private static int ReadTableIdOrFail()
    {
        Console.Write("TableId: ");
        return int.TryParse(Console.ReadLine(), out var tableId) ? tableId : throw new ArgumentException("Invalid tableId.");
    }


    public async Task AddReservationUI()
    {
        var reservationDate = ReadReservationDateOrFail();
        var partySize = ReadPartySizeOrFail();
        var restaurantId = ReadRestaurantIdOrFail();
        var customerId = ReadCustomerIdOrFail();
        var tableId = ReadTableIdOrFail();

        try
        {
            await _service.AddReservationAsync(reservationDate,partySize,restaurantId,customerId,tableId);
            Console.WriteLine("Reservation successfully created!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateReservationReservationDateUI()
    {
        try
        {
            var id = ReadIdOrFail();
            var reservationDate = ReadReservationDateOrFail();

            await _service.UpdateReservationDateAsync(id, reservationDate);
            Console.WriteLine("Reservation date was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateReservationPartySizeUI()
    {
        try
        {
            var id = ReadIdOrFail();
            var partySize = ReadPartySizeOrFail();

            await _service.UpdateReservationSizeAsync(id, partySize);
            Console.WriteLine("Reservation PartySize was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateReservationRestaurantUI()
    {
        try
        {
            var id = ReadIdOrFail();
            var restaurantId = ReadRestaurantIdOrFail();

            await _service.UpdateReservationRestaurantAsync(id, restaurantId);
            Console.WriteLine("Reservation Restaurant was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateReservationCustomerUI()
    {
        try
        {
            var id = ReadIdOrFail();
            var customerId = ReadCustomerIdOrFail();

            await _service.UpdateReservationCustomerAsync(id, customerId);
            Console.WriteLine("Reservation Customer was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task UpdateReservationTableUI()
    {
        try
        {
            var id = ReadIdOrFail();
            var tableId = ReadTableIdOrFail();

            await _service.UpdateReservationTableAsync(id, tableId);
            Console.WriteLine("Reservation Table was successfully updated!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task DeleteReservation()
    {
        try
        {
            var id = ReadIdOrFail();

            await _service.DeleteReservationAsync(id);
            Console.WriteLine("Reservation was successfully deleted!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public async Task GetReservationUI()
    {
        var id = ReadIdOrFail();
        var reservation = await _service.GetReservationByIdAsync(id);

        Console.WriteLine($"ReservationId: {reservation.ReservationId},\n   ReservationDate: {reservation.ReservationDate}," +
        $"\n    PartySize: {reservation.PartySize},\n    RestaurantId: {reservation.RestaurantId}, " +
        $"\n    CustomerId: {reservation.CustomerId},\n    TableId: {reservation.TableId}");
        reservation.orders.ForEach(o => Console.WriteLine($"    OrderId: { o.OrderId}," +
            $"\n    OrderDate: { o.OrderDate},\n    TotalAmount: {o.TotalAmount}," +
            $"\n    ReservationId: {o.ReservationId},\n    EmployeeId: {o.EmployeeId}"));
    }

    public async Task GetReservationsUI()
    {
        var reservations = await _service.GetReservationsAsync();
        foreach (var reservation in reservations)
        {
            Console.WriteLine($"ReservationId: {reservation.ReservationId},\n   ReservationDate: {reservation.ReservationDate}," +
            $"\n    PartySize: {reservation.PartySize},\n    RestaurantId: {reservation.RestaurantId}, " +
            $"\n    CustomerId: {reservation.CustomerId},\n    TableId: {reservation.TableId}");
            reservation.orders.ForEach(o => Console.WriteLine($"    OrderId: {o.OrderId}," +
                $"\n OrderDate: {o.OrderDate},\n    TotalAmount: {o.TotalAmount}," +
                $"\n    ReservationId: {o.ReservationId},\n    EmployeeId: {o.EmployeeId}"));
        }
    }
}
