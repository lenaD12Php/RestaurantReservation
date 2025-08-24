using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db;

public class RestaurantReservationDbContext : DbContext 
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Table> Tables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database =  RestaurantReservationCore; Integrated Security=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MenuItem>().
           HasMany(mi => mi.Orders)
           .WithMany(o => o.MenuItems)
           .UsingEntity<OrderItem>(
           join => join.HasOne<Order>()
           .WithMany()
           .HasForeignKey(oi => oi.OrderId),
           join => join.HasOne<MenuItem>()
           .WithMany()
           .HasForeignKey(oi => oi.MenuItemId));
        modelBuilder.Entity<OrderItem>()
          .Property(oi => oi.Quantity).HasDefaultValueSql("0");
        modelBuilder.Entity<OrderItem>()
            .Property(oi => oi.OrderId).HasColumnName("order_id");
        modelBuilder.Entity<OrderItem>()
          .Property(oi => oi.MenuItemId).HasColumnName("item_id");

        modelBuilder.Entity<OrderItem>()
            .Property(oi => oi.OrderItemId)
            .HasColumnName("order_item_id");
        modelBuilder.Entity<OrderItem>()
            .Property(oi => oi.MenuItemId)
            .HasColumnName("item_id");
        modelBuilder.Entity<OrderItem>()
            .Property(oi => oi.OrderId)
            .HasColumnName("order_id");

        modelBuilder.Entity<Customer>()
          .Property(c => c.CustomerId)
          .HasColumnName("customer_id");
        modelBuilder.Entity<Customer>()
           .Property(c => c.Firstname)
           .HasColumnName("first_name");
        modelBuilder.Entity<Customer>()
       .Property(c => c.Lastname)
       .HasColumnName("last_name");
        modelBuilder.Entity<Customer>()
       .Property(c => c.PhoneNumber)
       .HasColumnName("phone_number");

        modelBuilder.Entity<Reservation>()
            .Property(r => r.ReservationId)
            .HasColumnName("reservation_id");
        modelBuilder.Entity<Reservation>()
           .Property(r => r.ReservationDate)
           .HasColumnName("reservation_date");
        modelBuilder.Entity<Reservation>()
           .Property(r => r.PartySize)
           .HasColumnName("party_size");
        modelBuilder.Entity<Reservation>()
           .Property(r => r.CustomerId)
           .HasColumnName("customer_id");
        modelBuilder.Entity<Reservation>()
           .Property(r => r.RestaurantId)
           .HasColumnName("restaurant_id");
        modelBuilder.Entity<Reservation>()
           .Property(r => r.TableId)
           .HasColumnName("table_id");

        modelBuilder.Entity<Order>()
           .Property(o => o.OrderId)
           .HasColumnName("order_id");
        modelBuilder.Entity<Order>()
        .Property(o => o.ReservationId)
        .HasColumnName("reservation_id");
        modelBuilder.Entity<Order>()
        .Property(o => o.EmployeeId)
        .HasColumnName("employee_id");
        modelBuilder.Entity<Order>()
        .Property(o => o.OrderDate)
        .HasColumnName("order_date");
        modelBuilder.Entity<Order>()
        .Property(o => o.TotalAmount)
        .HasColumnName("total_amount");

        modelBuilder.Entity<Employee>()
            .Property(e => e.EmployeeId)
            .HasColumnName("employee_id");
        modelBuilder.Entity<Employee>()
          .Property(e => e.RestaurantId)
          .HasColumnName("restaurant_id");
        modelBuilder.Entity<Employee>()
          .Property(e => e.Firstname)
          .HasColumnName("first_name");
        modelBuilder.Entity<Employee>()
          .Property(e => e.Lastname)
          .HasColumnName("last_name");

        modelBuilder.Entity<MenuItem>()
            .Property(mi => mi.MenuItemId)
            .HasColumnName("item_id");
        modelBuilder.Entity<MenuItem>()
          .Property(mi => mi.RestaurantId)
          .HasColumnName("restaurant_id");

        modelBuilder.Entity<Table>()
            .Property(t => t.TableId)
            .HasColumnName("table_id");
        modelBuilder.Entity<Table>()
           .Property(t => t.RestaurantId)
           .HasColumnName("restaurant_id");

        modelBuilder.Entity<Restaurant>()
            .Property(r => r.RestaurantId)
            .HasColumnName("restaurant_id");
        modelBuilder.Entity<Restaurant>()
          .Property(r => r.PhoneNumber)
          .HasColumnName("phone_number");
        modelBuilder.Entity<Restaurant>()
          .Property(r => r.OpeningHours)
          .HasColumnName("opening_hours");
    }
}


