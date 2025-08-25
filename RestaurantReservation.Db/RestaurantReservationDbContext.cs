using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Enums;

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
        modelBuilder.Entity<Employee>()
            .Property(e => e.Position)
            .HasConversion<string>();

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

        var customers = new List<Customer>()
        {
            new Customer
            {
                CustomerId = 1,
                Firstname = "Lena",
                Lastname = "Damisi",
                Email = "Lena12D@gmail.com",
                PhoneNumber = "1234567890",
            },
            new Customer
            {
                CustomerId = 2,
                Firstname = "Jaber",
                Lastname = "Muhsen",
                Email = "JaberMuh@gmail.com",
                PhoneNumber = "9834567892",
            },
            new Customer
            {
                CustomerId = 3,
                Firstname = "Hiba",
                Lastname = "Bashar",
                Email = "HibaBashar@gmail.com",
                PhoneNumber = "1234568880",
            },
            new Customer
            {
                CustomerId = 4,
                Firstname = "Aisha",
                Lastname = "Khaled",
                Email = "AishaKhaled@yahoo.com",
                PhoneNumber = "1279199990"
            },
            new Customer
            {
                CustomerId = 5,
                Firstname = "Aya",
                Lastname = "Jaradat",
                Email = "AJaradat@gmail.com",
                PhoneNumber = "1267867890"
            }
        };
        modelBuilder.Entity<Customer>().HasData(customers);

        var restaurants = new List<Restaurant>()
        {
            new Restaurant()
            {
                RestaurantId = 1,
                Name = "Köz",
                Address = "Bahnhof Straße nr.1, Stade",
                PhoneNumber = "3389808990",
                OpeningHours = "Everyday 8-12am"
            },
            new Restaurant()
            {
                RestaurantId = 2,
                Name = "Teen o Zaytoon",
                Address = "Jenin old city",
                PhoneNumber = "0988765876",
                OpeningHours = "Everyday 24/7"
            },
            new Restaurant()
            {
                RestaurantId = 3,
                Name = "DeliKitchen",
                Address = "Nablus street 1",
                PhoneNumber = "0889982348",
                OpeningHours = "Friday and Saturday off,\n 9-12am S-T"
            },
            new Restaurant()
            {
                RestaurantId = 4,
                Name = "Donuts Bites",
                Address = "Jarrar street",
                PhoneNumber = "1236758889",
                OpeningHours = "9-1am Everyday"
            },
            new Restaurant()
            {
                RestaurantId = 5,
                Name = "Pizza House",
                Address = "Qabatiya cafe area",
                PhoneNumber = "8972346757",
                OpeningHours = "11am-11:59pm"
            }
        };
        modelBuilder.Entity<Restaurant>().HasData(restaurants);

        var tables = new List<Table>()
        {
            new Table()
            {
                TableId = 1,
                Capacity = Capacity.Two,
                RestaurantId = 1
            },
            new Table()
            {
                TableId = 2,
                Capacity = Capacity.Four,
                RestaurantId = 2
            },
            new Table()
            {
                TableId = 3,
                Capacity = Capacity.Six,
                RestaurantId = 3
            },
            new Table()
            {
                TableId = 4,
                Capacity = Capacity.Two,
                RestaurantId = 4
            },
            new Table()
            {
                TableId = 5,
                Capacity = Capacity.Four,
                RestaurantId = 5
            }
        };
        modelBuilder.Entity<Table>().HasData(tables);

        var reservations = new List<Reservation>()
        {
            new Reservation() 
            {
                ReservationId = 1,
                RestaurantId = 1,
                ReservationDate = new DateTime(2025,8,31),
                PartySize = 2,
                CustomerId = 1,
                TableId = 1
            },
            new Reservation()
            {
                ReservationId = 2,
                RestaurantId = 2,
                ReservationDate = new DateTime(2025,7,2),
                PartySize = 2,
                CustomerId = 2,
                TableId = 2
            },
            new Reservation()
            {
                ReservationId = 3,
                RestaurantId = 3,
                ReservationDate = new DateTime(2025,8,10),
                PartySize = 5,
                CustomerId = 1,
                TableId = 3
            },
            new Reservation()
            {
                ReservationId = 4,
                RestaurantId = 4,
                ReservationDate = new DateTime(2025,7,11),
                PartySize = 2,
                CustomerId = 3,
                TableId = 4
            },
            new Reservation()
            {
                ReservationId = 5,
                RestaurantId = 3,
                ReservationDate = new DateTime(2025,8,31),
                PartySize = 6,
                CustomerId = 5,
                TableId = 3
            }
        };
        modelBuilder.Entity<Reservation>().HasData(reservations);

        var employees = new List<Employee>()
        { 
            new Employee
            {
                EmployeeId = 1, 
                RestaurantId = 1,
                Firstname = "Sama",
                Lastname = "Jamal",
                Position=Position.Manager
            },
            new Employee
            {
                EmployeeId = 2,
                RestaurantId = 2,
                Firstname = "Zahraa",
                Lastname = "Alwadi",
                Position=Position.Manager
            },
            new Employee
            {
                EmployeeId = 3,
                RestaurantId = 3,
                Firstname = "Shams",
                Lastname = "Eweis",
                Position = Position.Server
            },
            new Employee
            {
                EmployeeId = 4,
                RestaurantId = 4,
                Firstname = "Ahlam",
                Lastname = "Hilmi",
                Position = Position.Cashier
            },
            new Employee
            {
                EmployeeId = 5,
                RestaurantId = 5,
                Firstname = "Sewar",
                Lastname = "Anwar",
                Position = Position.Chef
            }
        };
        modelBuilder.Entity<Employee>().HasData(employees);

        var menuItems = new List<MenuItem>()
        {
            new MenuItem
            {
                MenuItemId = 1,
                RestaurantId = 1,
                Name = "Kabseh",
                Description = "Chicken/Beef/Lamb with Rice spices and Veggies",
                Price = 30.50m
            },
            new MenuItem
            {
                MenuItemId = 2,
                RestaurantId = 2,
                Name = "Shishbarak",
                Description = "Dough stuffed with diced onion, beef and dried mint, cooked in yogurt and served with rice",
                Price = 30.00m
            },
            new MenuItem
            {
                MenuItemId = 3,
                RestaurantId = 3,
                Name = "Dawali",
                Description = "Grape leaves stuffed with short-rice and veggies cooked with lots of lemon juice and olive oil",
                Price = 15.50m
            },
            new MenuItem
            {
                MenuItemId=4,
                RestaurantId = 4,
                Name = "Matilda chocolate cake slice",
                Description = "Moist Chocolate cake with chocolate ganache and chocolate sauce",
                Price = 10.00m
            },
            new MenuItem
            {
                MenuItemId = 5,
                RestaurantId = 5,
                Name = "Pizza",
                Description = "Dough, Tomato Sauce , Cheese and Toppings of your choice",
                Price = 35.50m
            }
        };
        modelBuilder.Entity<MenuItem>().HasData(menuItems);

        var orders = new List<Order>()
        {
            new Order
            {
                OrderId = 1,
                ReservationId = 1,
                EmployeeId = 1,
                OrderDate = new DateTime(2025,8,31),
                TotalAmount = 91.50m
            },
            new Order
            {
                OrderId = 2,
                ReservationId = 2,
                EmployeeId = 2,
                OrderDate = new DateTime(2025,7,2),
                TotalAmount = 60.00m
            },
            new Order
            {
                OrderId = 3,
                ReservationId = 3,
                EmployeeId = 3,
                OrderDate = new DateTime(2025,8,10),
                TotalAmount = 77.50m
            },
            new Order
            {
                OrderId=4,
                ReservationId = 5,
                EmployeeId = 3,
                OrderDate = new DateTime(2025,8,31),
                TotalAmount = 108.50m
            },
            new Order
            {
                OrderId=5,
                ReservationId = 4,
                EmployeeId = 4,
                OrderDate = new DateTime(2025,7,11),
                TotalAmount = 40.00m
            }
        };
        modelBuilder.Entity<Order>().HasData(orders);

        var OrderItems = new List<OrderItem>()
        {
            new OrderItem
            {
                OrderItemId = 1,
                OrderId = 1,
                MenuItemId = 1,
                Quantity = 3
            },
            new OrderItem
            {
                OrderItemId = 2,
                OrderId = 2,
                MenuItemId = 2,
                Quantity = 2
            },
            new OrderItem
            {
                OrderItemId = 3,
                OrderId = 3,
                MenuItemId = 3,
                Quantity = 5
            },
            new OrderItem
            {
                OrderItemId = 4,
                OrderId = 4,
                MenuItemId = 3,
                Quantity = 7
            },
            new OrderItem
            {
                OrderItemId = 5,
                OrderId = 5,
                MenuItemId = 4,
                Quantity = 4
            }
        };
        modelBuilder.Entity<OrderItem>().HasData(OrderItems);
    }
}


