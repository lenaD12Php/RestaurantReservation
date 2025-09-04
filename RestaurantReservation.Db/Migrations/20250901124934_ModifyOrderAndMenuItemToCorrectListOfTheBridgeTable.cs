using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class ModifyOrderAndMenuItemToCorrectListOfTheBridgeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_MenuItems_item_id",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Orders_order_id",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_order_id",
                table: "OrderItem");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "OrderItems");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_item_id",
                table: "OrderItems",
                newName: "IX_OrderItems_item_id");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "0");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "order_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_order_id_item_id",
                table: "OrderItems",
                columns: new[] { "order_id", "item_id" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_MenuItems_item_id",
                table: "OrderItems",
                column: "item_id",
                principalTable: "MenuItems",
                principalColumn: "item_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_order_id",
                table: "OrderItems",
                column: "order_id",
                principalTable: "Orders",
                principalColumn: "order_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_MenuItems_item_id",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_order_id",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_order_id_item_id",
                table: "OrderItems");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrderItem");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_item_id",
                table: "OrderItem",
                newName: "IX_OrderItem_item_id");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "OrderItem",
                type: "int",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "order_item_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_order_id",
                table: "OrderItem",
                column: "order_id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_MenuItems_item_id",
                table: "OrderItem",
                column: "item_id",
                principalTable: "MenuItems",
                principalColumn: "item_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Orders_order_id",
                table: "OrderItem",
                column: "order_id",
                principalTable: "Orders",
                principalColumn: "order_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
