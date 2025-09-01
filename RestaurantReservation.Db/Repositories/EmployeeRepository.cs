using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Enums;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly RestaurantReservationDbContext _context;

    public EmployeeRepository(RestaurantReservationDbContext context) => _context = context;
    
    public async Task AddEmployeeAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEmployeeAsync(Employee employee)
    {
        var entity = await _context.Employees.FindAsync(new object[] { employee.EmployeeId });
        if (entity is null) return;

        _context.Employees.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Employee>> GetEmployeesAsync()
    {
        return await _context.Employees.AsNoTracking().Include(e => e.Orders).ToListAsync();
    }

    public async Task<Employee?> GetEmployeeByIdAsync(int employeeId)
    {
        return await _context.Employees.AsNoTracking().Include(e => e.Orders).FirstOrDefaultAsync( e => e.EmployeeId == employeeId);
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        var tracked = _context.Employees.Local
        .FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
        if (tracked != null)
            _context.Entry(tracked).State = EntityState.Detached;

        _context.Attach(employee);
        _context.Entry(employee).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<List<Employee>> ListManagersAsync()
    {
        return await _context.Employees.AsNoTracking().Where(e => e.Position == Position.Manager).ToListAsync();
    }
}
