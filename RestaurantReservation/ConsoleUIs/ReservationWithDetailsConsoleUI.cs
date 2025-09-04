using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.ConsoleUIs;

public class ReservationWithDetailsConsoleUI
{
    private readonly IReservationWithDetailsService _service;
    public ReservationWithDetailsConsoleUI(IReservationWithDetailsService service) => _service = service;

    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine("\n1) Get Reservations with customer and restaurant details  \n0) Exit");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    await GetReservationsWithCustomerAndRestaurantDetailsUI();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Pick a valid option.");
                    break;
            }
        }
    }

    public async Task GetReservationsWithCustomerAndRestaurantDetailsUI()
    {
        var reservationsWithDetails = await _service.GetReservationsWithCustomerAndRestaurantDetailsAsync();
        foreach (var res in reservationsWithDetails)
        {
            Console.WriteLine($"ReservationId: {res.ReservationId},\n    RestaurantId: {res.RestaurantId}," +
                $"\n    RestaurantName: {res.RestaurantName},\n    RestaurantAddress: {res.RestaurantAddress}," +
                $"\n    RestaurantPhone: {res.RestaurantPhoneNumber},\n    ReservationDate: {res.ReservationDate}," +
                $"\n    TableId: {res.TableId},\n    PartySize: {res.PartySize}," +
                $"\n    CustomerId: {res.CustomerId},\n    CustomerName: {res.CustomerName}," +
                $"\n    CustomerPhone: {res.CustomerPhoneNumber}");
        }
    }
}
