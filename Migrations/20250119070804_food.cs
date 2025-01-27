using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodBooking4.Migrations
{
    /// <inheritdoc />
    public partial class food : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "EmpId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "orderItems",
                newName: "ComboId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmpId",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ComboId",
                table: "orderItems",
                newName: "ItemId");
        }
    }
}
