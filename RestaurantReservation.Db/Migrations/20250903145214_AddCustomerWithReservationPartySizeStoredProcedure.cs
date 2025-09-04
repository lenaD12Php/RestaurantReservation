using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerWithReservationPartySizeStoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
               @"create procedure CustomerWithGreaterPartySize
		                    @partySize int
                    as 
                    select c.*, r.party_size from Customers as c
                    left join Reservations as r on c.customer_id = r.customer_id
                    where r.party_size >= @partySize;");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop procedure CustomerWithGreaterPartySize;");
        }
    }
}
