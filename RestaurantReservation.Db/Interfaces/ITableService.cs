using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Enums;

namespace RestaurantReservation.Db.Interfaces;

public interface ITableService
{
    Task<Table> GetTableByIdAsync(int tableId);
    Task<List<Table>> GetTablesAsync();
    Task AddTableAsync(Capacity capacity,int restaurantId);
    Task DeleteTableAsync(int tableId);
    Task UpdateTableCapacityAsync(int tableId, Capacity capacity);
    Task UpdateTableRestaurantAsync(int tableId, int restaurantId);
}
