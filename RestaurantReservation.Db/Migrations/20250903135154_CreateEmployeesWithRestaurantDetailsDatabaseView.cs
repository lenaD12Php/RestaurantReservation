using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class CreateEmployeesWithRestaurantDetailsDatabaseView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql
            (
                @"create view EmployeesWithRestaurantDetails
                   as
                   select emp.employee_id,
                   emp.first_name +' '+ emp.last_name as employee_name,
                   emp.Position as employee_position,
                   rest.restaurant_id,
                   rest.Name as restaurant_name,
                   rest.Address as restaurant_address,
                   rest.phone_number as restaurant_phone,
                   rest.opening_hours as restaurant_opening_hours
                   from Employees emp
                   left join Restaurants rest on emp.restaurant_id = rest.restaurant_id;"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view EmployeesWithRestaurantDetails;");
        }
    }
}
