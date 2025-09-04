using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories;

public class TableRepository : ITableRepository
{
    private readonly RestaurantReservationDbContext _context;

    public TableRepository (RestaurantReservationDbContext context) => _context = context;

    public async Task AddTableAsync(Table table)
    {
        await _context.Tables.AddAsync(table);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTableAsync(Table table)
    {
        var entity = await _context.Tables.FindAsync(new object[] { table.TableId });
        if (entity is null) return;

        _context.Tables.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Table?> GetTableByIdAsync(int tableId)
    {
        return await _context.Tables.AsNoTracking().FirstOrDefaultAsync(t => t.TableId==tableId);
    }

    public async  Task<List<Table>> GetTablesAsync()
    {
        return await _context.Tables.AsNoTracking().ToListAsync();
    }

    public async Task UpdateTableAsync(Table table)
    {
        var tracked = _context.Tables.Local
        .FirstOrDefault(c => c.TableId == table.TableId);
        if (tracked != null)
            _context.Entry(tracked).State = EntityState.Detached;

        _context.Attach(table);
        _context.Entry(table).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
