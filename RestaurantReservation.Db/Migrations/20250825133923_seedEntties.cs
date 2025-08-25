using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class seedEntties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "customer_id", "Email", "first_name", "last_name", "phone_number" },
                values: new object[,]
                {
                    { 1, "Lena12D@gmail.com", "Lena", "Damisi", "1234567890" },
                    { 2, "JaberMuh@gmail.com", "Jaber", "Muhsen", "9834567892" },
                    { 3, "HibaBashar@gmail.com", "Hiba", "Bashar", "1234568880" },
                    { 4, "AishaKhaled@yahoo.com", "Aisha", "Khaled", "1279199990" },
                    { 5, "AJaradat@gmail.com", "Aya", "Jaradat", "1267867890" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "restaurant_id", "Address", "Name", "opening_hours", "phone_number" },
                values: new object[,]
                {
                    { 1, "Bahnhof Straße nr.1, Stade", "Köz", "Everyday 8-12am", "3389808990" },
                    { 2, "Jenin old city", "Teen o Zaytoon", "Everyday 24/7", "0988765876" },
                    { 3, "Nablus street 1", "DeliKitchen", "Friday and Saturday off,\n 9-12am S-T", "0889982348" },
                    { 4, "Jarrar street", "Donuts Bites", "9-1am Everyday", "1236758889" },
                    { 5, "Qabatiya cafe area", "Pizza House", "11am-11:59pm", "8972346757" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "employee_id", "first_name", "last_name", "Position", "restaurant_id" },
                values: new object[,]
                {
                    { 1, "Sama", "Jamal", "Manager", 1 },
                    { 2, "Zahraa", "Alwadi", "Manager", 2 },
                    { 3, "Shams", "Eweis", "Server", 3 },
                    { 4, "Ahlam", "Hilmi", "Cashier", 4 },
                    { 5, "Sewar", "Anwar", "Chef", 5 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "item_id", "Description", "Name", "Price", "restaurant_id" },
                values: new object[,]
                {
                    { 1, "Chicken/Beef/Lamb with Rice spices and Veggies", "Kabseh", 30.50m, 1 },
                    { 2, "Dough stuffed with diced onion, beef and dried mint, cooked in yogurt and served with rice", "Shishbarak", 30.00m, 2 },
                    { 3, "Grape leaves stuffed with short-rice and veggies cooked with lots of lemon juice and olive oil", "Dawali", 15.50m, 3 },
                    { 4, "Moist Chocolate cake with chocolate ganache and chocolate sauce", "Matilda chocolate cake slice", 10.00m, 4 },
                    { 5, "Dough, Tomato Sauce , Cheese and Toppings of your choice", "Pizza", 35.50m, 5 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "table_id", "Capacity", "restaurant_id" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 4, 2 },
                    { 3, 6, 3 },
                    { 4, 2, 4 },
                    { 5, 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "reservation_id", "customer_id", "party_size", "reservation_date", "restaurant_id", "table_id" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(2025, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, 2, 2, new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, 1, 5, new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 4, 3, 2, new DateTime(2025, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4 },
                    { 5, 5, 6, new DateTime(2025, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "order_id", "employee_id", "order_date", "reservation_id", "total_amount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 91.50m },
                    { 2, 2, new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 60.00m },
                    { 3, 3, new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 77.50m },
                    { 4, 3, new DateTime(2025, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 108.50m },
                    { 5, 4, new DateTime(2025, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 40.00m }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "order_item_id", "item_id", "order_id", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 3 },
                    { 2, 2, 2, 2 },
                    { 3, 3, 3, 5 },
                    { 4, 3, 4, 7 },
                    { 5, 4, 5, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customer_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "employee_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "item_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "order_item_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "order_item_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "order_item_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "order_item_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "order_item_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "table_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "item_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "item_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "item_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "item_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "order_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "restaurant_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "employee_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "employee_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "employee_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "employee_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "reservation_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customer_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customer_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customer_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "customer_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "table_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "table_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "table_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "table_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "restaurant_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "restaurant_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "restaurant_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "restaurant_id",
                keyValue: 4);
        }
    }
}
