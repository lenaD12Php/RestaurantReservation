using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Enums;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Services;


public class TableService : ITableService
{
    private readonly ITableRepository _repository;

    public TableService(ITableRepository repository) => _repository = repository;

    public async Task AddTableAsync(Capacity capacity, int restaurantId)
    {
        var table = new Table
        {
            Capacity = capacity,
            RestaurantId = restaurantId
        };

        await _repository.AddTableAsync(table);
    }

    public async Task DeleteTableAsync(int tableId)
    {
        var table = await _repository.GetTableByIdAsync(tableId);

        await _repository.DeleteTableAsync(table);
    }

    public async Task<Table> GetTableByIdAsync(int tableId)
    {
       return await _repository.GetTableByIdAsync(tableId);
    }

    public async Task<List<Table>> GetTablesAsync()
    {
        return await _repository.GetTablesAsync();
    }

    public async Task UpdateTableCapacityAsync(int tableId, Capacity capacity)
    {
        var table = await _repository.GetTableByIdAsync(tableId);
        table.Capacity = capacity;

        await _repository.UpdateTableAsync(table);
    }

    public async Task UpdateTableRestaurantAsync(int tableId, int restaurantId)
    {
        var table = await _repository.GetTableByIdAsync(tableId);
        table.RestaurantId = restaurantId;

        await _repository.UpdateTableAsync(table);
    }
}
