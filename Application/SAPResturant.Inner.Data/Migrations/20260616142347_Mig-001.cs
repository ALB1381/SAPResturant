using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SAPResturant.Inner.Data.Migrations
{
    /// <inheritdoc />
    public partial class Mig001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ExtraOnItems",
                columns: new[] { "ExtraOnItemId", "ExtraOnItemDescription", "ExtraOnItemPrice", "ExtraOnItemTitle", "MaderLog" },
                values: new object[,]
                {
                    { 1, null, 2, "Extra Espresso Shot", "SystemSeed" },
                    { 2, null, 1, "Oat Milk Alternative", "SystemSeed" },
                    { 3, null, 3, "Add Bacon", "SystemSeed" },
                    { 4, null, 2, "Extra Cheese", "SystemSeed" },
                    { 5, null, 1, "Vanilla Syrup", "SystemSeed" }
                });

            migrationBuilder.InsertData(
                table: "ItemGroups",
                columns: new[] { "ItemGroupId", "GroupBgColor", "GroupCardColors", "GroupName", "GroupTextColor", "MaderLog", "ParentId" },
                values: new object[,]
                {
                    { 1, null, null, "Hot Coffee", null, "SystemSeed", null },
                    { 2, null, null, "Cold Beverages", null, "SystemSeed", null },
                    { 3, null, null, "Breakfast", null, "SystemSeed", null },
                    { 4, null, null, "Sandwiches & Wraps", null, "SystemSeed", null },
                    { 5, null, null, "Burgers", null, "SystemSeed", null },
                    { 6, null, null, "Desserts", null, "SystemSeed", null }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "ItemDescription", "ItemGroupId", "ItemImage", "ItemIngrediants", "ItemName", "ItemSubGroupId", "MaderLog" },
                values: new object[,]
                {
                    { 1, null, 1, null, null, "Espresso", null, "SystemSeed" },
                    { 2, null, 1, null, null, "Double Espresso", null, "SystemSeed" },
                    { 3, null, 1, null, null, "Americano", null, "SystemSeed" },
                    { 4, null, 1, null, null, "Cappuccino", null, "SystemSeed" },
                    { 5, null, 1, null, null, "Latte", null, "SystemSeed" },
                    { 6, null, 1, null, null, "Mocha", null, "SystemSeed" },
                    { 7, null, 1, null, null, "Macchiato", null, "SystemSeed" },
                    { 8, null, 1, null, null, "Flat White", null, "SystemSeed" },
                    { 9, null, 1, null, null, "Hot Chocolate", null, "SystemSeed" },
                    { 10, null, 1, null, null, "Chai Tea Latte", null, "SystemSeed" },
                    { 11, null, 2, null, null, "Iced Americano", null, "SystemSeed" },
                    { 12, null, 2, null, null, "Iced Latte", null, "SystemSeed" },
                    { 13, null, 2, null, null, "Cold Brew", null, "SystemSeed" },
                    { 14, null, 2, null, null, "Frappuccino", null, "SystemSeed" },
                    { 15, null, 2, null, null, "Iced Peach Tea", null, "SystemSeed" },
                    { 16, null, 2, null, null, "Lemonade", null, "SystemSeed" },
                    { 17, null, 2, null, null, "Fresh Orange Juice", null, "SystemSeed" },
                    { 18, null, 2, null, null, "Mango Smoothie", null, "SystemSeed" },
                    { 19, null, 3, null, null, "Classic Pancakes", null, "SystemSeed" },
                    { 20, null, 3, null, null, "Belgian Waffle", null, "SystemSeed" },
                    { 21, null, 3, null, null, "Avocado Toast", null, "SystemSeed" },
                    { 22, null, 3, null, null, "Eggs Benedict", null, "SystemSeed" },
                    { 23, null, 3, null, null, "Oatmeal Bowl", null, "SystemSeed" },
                    { 24, null, 3, null, null, "Bagel with Cream Cheese", null, "SystemSeed" },
                    { 25, null, 4, null, null, "Club Sandwich", null, "SystemSeed" },
                    { 26, null, 4, null, null, "BLT Sandwich", null, "SystemSeed" },
                    { 27, null, 4, null, null, "Grilled Cheese", null, "SystemSeed" },
                    { 28, null, 4, null, null, "Tuna Salad Sandwich", null, "SystemSeed" },
                    { 29, null, 4, null, null, "Chicken Caesar Wrap", null, "SystemSeed" },
                    { 30, null, 4, null, null, "Veggie Wrap", null, "SystemSeed" },
                    { 31, null, 5, null, null, "Classic Cheeseburger", null, "SystemSeed" },
                    { 32, null, 5, null, null, "Bacon Burger", null, "SystemSeed" },
                    { 33, null, 5, null, null, "Mushroom Swiss Burger", null, "SystemSeed" },
                    { 34, null, 5, null, null, "Crispy Chicken Burger", null, "SystemSeed" },
                    { 35, null, 5, null, null, "Spicy Black Bean Burger", null, "SystemSeed" },
                    { 36, null, 6, null, null, "New York Cheesecake", null, "SystemSeed" },
                    { 37, null, 6, null, null, "Chocolate Fudge Cake", null, "SystemSeed" },
                    { 38, null, 6, null, null, "Tiramisu", null, "SystemSeed" },
                    { 39, null, 6, null, null, "Warm Brownie", null, "SystemSeed" },
                    { 40, null, 6, null, null, "Ice Cream Sundae", null, "SystemSeed" }
                });

            migrationBuilder.InsertData(
                table: "ExtraOnItemItemConnections",
                columns: new[] { "ConnectionId", "ExtraOnItemId", "ItemId", "MaderLog" },
                values: new object[,]
                {
                    { 1, 1, 5, "SystemSeed" },
                    { 2, 1, 4, "SystemSeed" },
                    { 3, 1, 12, "SystemSeed" },
                    { 4, 2, 5, "SystemSeed" },
                    { 5, 2, 7, "SystemSeed" },
                    { 6, 2, 10, "SystemSeed" },
                    { 7, 3, 31, "SystemSeed" },
                    { 8, 3, 27, "SystemSeed" },
                    { 9, 3, 19, "SystemSeed" },
                    { 10, 4, 31, "SystemSeed" },
                    { 11, 4, 25, "SystemSeed" },
                    { 12, 5, 12, "SystemSeed" },
                    { 13, 5, 14, "SystemSeed" }
                });

            migrationBuilder.InsertData(
                table: "ItemCases",
                columns: new[] { "ItemCaseId", "AvaibleCount", "CasePrice", "CaseTitle", "DsicountId", "ItemId", "MaderLog" },
                values: new object[,]
                {
                    { 1, null, 5, "Standard", null, 1, "SystemSeed" },
                    { 2, null, 5, "Standard", null, 2, "SystemSeed" },
                    { 3, null, 5, "Standard", null, 3, "SystemSeed" },
                    { 4, null, 5, "Standard", null, 4, "SystemSeed" },
                    { 5, null, 5, "Standard", null, 5, "SystemSeed" },
                    { 6, null, 5, "Standard", null, 6, "SystemSeed" },
                    { 7, null, 5, "Standard", null, 7, "SystemSeed" },
                    { 8, null, 5, "Standard", null, 8, "SystemSeed" },
                    { 9, null, 5, "Standard", null, 9, "SystemSeed" },
                    { 10, null, 5, "Standard", null, 10, "SystemSeed" },
                    { 11, null, 5, "Standard", null, 11, "SystemSeed" },
                    { 12, null, 5, "Standard", null, 12, "SystemSeed" },
                    { 13, null, 5, "Standard", null, 13, "SystemSeed" },
                    { 14, null, 5, "Standard", null, 14, "SystemSeed" },
                    { 15, null, 5, "Standard", null, 15, "SystemSeed" },
                    { 16, null, 5, "Standard", null, 16, "SystemSeed" },
                    { 17, null, 5, "Standard", null, 17, "SystemSeed" },
                    { 18, null, 5, "Standard", null, 18, "SystemSeed" },
                    { 19, null, 12, "Standard", null, 19, "SystemSeed" },
                    { 20, null, 12, "Standard", null, 20, "SystemSeed" },
                    { 21, null, 12, "Standard", null, 21, "SystemSeed" },
                    { 22, null, 12, "Standard", null, 22, "SystemSeed" },
                    { 23, null, 12, "Standard", null, 23, "SystemSeed" },
                    { 24, null, 12, "Standard", null, 24, "SystemSeed" },
                    { 25, null, 12, "Standard", null, 25, "SystemSeed" },
                    { 26, null, 12, "Standard", null, 26, "SystemSeed" },
                    { 27, null, 12, "Standard", null, 27, "SystemSeed" },
                    { 28, null, 12, "Standard", null, 28, "SystemSeed" },
                    { 29, null, 12, "Standard", null, 29, "SystemSeed" },
                    { 30, null, 12, "Standard", null, 30, "SystemSeed" },
                    { 31, null, 12, "Standard", null, 31, "SystemSeed" },
                    { 32, null, 12, "Standard", null, 32, "SystemSeed" },
                    { 33, null, 12, "Standard", null, 33, "SystemSeed" },
                    { 34, null, 12, "Standard", null, 34, "SystemSeed" },
                    { 35, null, 12, "Standard", null, 35, "SystemSeed" },
                    { 36, null, 7, "Standard", null, 36, "SystemSeed" },
                    { 37, null, 7, "Standard", null, 37, "SystemSeed" },
                    { 38, null, 7, "Standard", null, 38, "SystemSeed" },
                    { 39, null, 7, "Standard", null, 39, "SystemSeed" },
                    { 40, null, 7, "Standard", null, 40, "SystemSeed" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExtraOnItemItemConnections",
                keyColumn: "ConnectionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExtraOnItemItemConnections",
                keyColumn: "ConnectionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExtraOnItemItemConnections",
                keyColumn: "ConnectionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExtraOnItemItemConnections",
                keyColumn: "ConnectionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ExtraOnItemItemConnections",
                keyColumn: "ConnectionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ExtraOnItemItemConnections",
                keyColumn: "ConnectionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ExtraOnItemItemConnections",
                keyColumn: "ConnectionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ExtraOnItemItemConnections",
                keyColumn: "ConnectionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ExtraOnItemItemConnections",
                keyColumn: "ConnectionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ExtraOnItemItemConnections",
                keyColumn: "ConnectionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ExtraOnItemItemConnections",
                keyColumn: "ConnectionId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ExtraOnItemItemConnections",
                keyColumn: "ConnectionId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ExtraOnItemItemConnections",
                keyColumn: "ConnectionId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ItemCases",
                keyColumn: "ItemCaseId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ExtraOnItems",
                keyColumn: "ExtraOnItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExtraOnItems",
                keyColumn: "ExtraOnItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExtraOnItems",
                keyColumn: "ExtraOnItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExtraOnItems",
                keyColumn: "ExtraOnItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ExtraOnItems",
                keyColumn: "ExtraOnItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ItemGroups",
                keyColumn: "ItemGroupId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ItemGroups",
                keyColumn: "ItemGroupId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ItemGroups",
                keyColumn: "ItemGroupId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ItemGroups",
                keyColumn: "ItemGroupId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ItemGroups",
                keyColumn: "ItemGroupId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ItemGroups",
                keyColumn: "ItemGroupId",
                keyValue: 6);
        }
    }
}
