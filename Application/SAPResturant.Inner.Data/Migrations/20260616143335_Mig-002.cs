using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SAPResturant.Inner.Data.Migrations
{
    /// <inheritdoc />
    public partial class Mig002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TableStatuses",
                columns: new[] { "TableStatusId", "MaderLog", "TableStatusName" },
                values: new object[,]
                {
                    { 1, "SystemSeed", "Free" },
                    { 2, "SystemSeed", "Taken" },
                    { 3, "SystemSeed", "Reserved" }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "CountOfSeats", "MaderLog", "PeriodHourOfReservation", "PriceOfReservation", "ResturantSectionId", "TableDescription", "TableName", "TableNumber", "TableStatusId" },
                values: new object[,]
                {
                    { 1, 8, "SystemSeed", null, null, null, "Something to describe it", "Dragon", 4, null },
                    { 2, 4, "SystemSeed", null, null, null, "Something to describe it", "Crown", 3, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TableStatuses",
                keyColumn: "TableStatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TableStatuses",
                keyColumn: "TableStatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TableStatuses",
                keyColumn: "TableStatusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 2);
        }
    }
}
