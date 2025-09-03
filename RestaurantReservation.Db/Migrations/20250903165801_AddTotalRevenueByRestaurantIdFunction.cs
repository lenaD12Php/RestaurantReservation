using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalRevenueByRestaurantIdFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @" create function fn_TotalRevenueForRestaurant
                    (
	                    @restaurantId INT
                    )
                        returns decimal(18,2)
                        as 
	                    begin

	                    declare @totalRevenue decimal(18,2);

	                    select @totalRevenue = Coalesce(sum(o.total_amount), 0.00)
                        from Orders o
                        inner join Reservations r on o.reservation_id = r.reservation_id
                        where r.restaurant_id = @restaurantId;

	                    return @totalRevenue;

                    end;
                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop function dbo.fn_TotalRevenueForRestaurant;");
        }
    }
}