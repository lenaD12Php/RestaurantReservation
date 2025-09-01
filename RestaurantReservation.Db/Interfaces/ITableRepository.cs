using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Interfaces;

public interface ITableRepository
{
    Task<Table?> GetTableByIdAsync(int tableId);
    Task<List<Table>> GetTablesAsync();
    Task AddTableAsync(Table table);
    Task DeleteTableAsync(Table table);
    Task UpdateTableAsync(Table table);
}
