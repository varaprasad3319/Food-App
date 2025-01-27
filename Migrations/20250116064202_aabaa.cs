using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodBooking4.Migrations
{
    /// <inheritdoc />
    public partial class aabaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Orders_OrdersOrderId",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "orderItems");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_OrdersOrderId",
                table: "orderItems",
                newName: "IX_orderItems_OrdersOrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderItems",
                table: "orderItems",
                column: "OrderItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItems_Orders_OrdersOrderId",
                table: "orderItems",
                column: "OrdersOrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItems_Orders_OrdersOrderId",
                table: "orderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderItems",
                table: "orderItems");

            migrationBuilder.RenameTable(
                name: "orderItems",
                newName: "OrderItem");

            migrationBuilder.RenameIndex(
                name: "IX_orderItems_OrdersOrderId",
                table: "OrderItem",
                newName: "IX_OrderItem_OrdersOrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "OrderItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Orders_OrdersOrderId",
                table: "OrderItem",
                column: "OrdersOrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }
    }
}
