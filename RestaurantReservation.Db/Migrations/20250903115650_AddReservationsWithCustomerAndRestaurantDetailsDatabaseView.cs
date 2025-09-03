using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationsWithCustomerAndRestaurantDetailsDatabaseView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql
            (
                @"Create view CustomerAndRestaurantByReservation
                    as 
                    select 
                    res.reservation_id, 
                    rest.restaurant_id, 
                    rest.Name   as restaurant_name,
                    rest.Address  as restaurant_address,
                    rest.phone_number as restaurant_phone,
                    res.reservation_date , 
                    res.table_id,res.party_size, 
                    c.customer_id, 
                    c.first_name +' '+ c.last_name as customer_name, 
                    c.phone_number as customer_phone
                    from Reservations res
                    left join Customers c  on  res.customer_id = c.customer_id
                    left join Restaurants rest on res.restaurant_id = rest.restaurant_id;"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view CustomerAndRestaurantByReservation");
        }
    }
}
