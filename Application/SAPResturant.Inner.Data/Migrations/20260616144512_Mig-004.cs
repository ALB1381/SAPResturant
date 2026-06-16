using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SAPResturant.Inner.Data.Migrations
{
    /// <inheritdoc />
    public partial class Mig004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "OrderStatusId", "MaderLog", "Percent", "StatusName" },
                values: new object[,]
                {
                    { 1, "SystemSeed", (short)10, "Initialized" },
                    { 2, "SystemSeed", (short)30, "Sent to kitchen" },
                    { 3, "SystemSeed", (short)60, "Cooking" },
                    { 4, "SystemSeed", (short)100, "Delivered" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "OrderStatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "OrderStatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "OrderStatusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "OrderStatusId",
                keyValue: 4);
        }
    }
}
