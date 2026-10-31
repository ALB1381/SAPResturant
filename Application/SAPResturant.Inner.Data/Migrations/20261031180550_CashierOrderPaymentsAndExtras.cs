using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SAPResturant.Inner.Data.Migrations
{
    /// <inheritdoc />
    public partial class CashierOrderPaymentsAndExtras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubInnerOrderExtraOnItemConnections",
                columns: table => new
                {
                    SubInnerOrderId = table.Column<int>(type: "int", nullable: false),
                    ExtraOnItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubInnerOrderExtraOnItemConnections", x => new { x.SubInnerOrderId, x.ExtraOnItemId });
                    table.ForeignKey(
                        name: "FK_SubInnerOrderExtraOnItemConnections_ExtraOnItems_ExtraOnItemId",
                        column: x => x.ExtraOnItemId,
                        principalTable: "ExtraOnItems",
                        principalColumn: "ExtraOnItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubInnerOrderExtraOnItemConnections_SubInnerOrders_SubInnerOrderId",
                        column: x => x.SubInnerOrderId,
                        principalTable: "SubInnerOrders",
                        principalColumn: "SubInnerOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "MethodId", "Free", "MaderLog", "TitleOfPaymentMethod" },
                values: new object[,]
                {
                    { 1, false, "SystemSeed", "Card" },
                    { 2, false, "SystemSeed", "Cash" },
                    { 3, true, "SystemSeed", "Personnel" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubInnerOrderExtraOnItemConnections_ExtraOnItemId",
                table: "SubInnerOrderExtraOnItemConnections",
                column: "ExtraOnItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubInnerOrderExtraOnItemConnections");

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "MethodId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "MethodId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "MethodId",
                keyValue: 3);
        }
    }
}
