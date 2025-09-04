using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAPResturant.Data.Migrations
{
    /// <inheritdoc />
    public partial class Mig001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                    table.ForeignKey(
                        name: "FK_Menus_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExteraItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ExteraOnItemTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExteraItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExteraItems_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemGroups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    VisualIdentityColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MenuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemGroups", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_ItemGroups_ItemGroups_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ItemGroups",
                        principalColumn: "GroupId");
                    table.ForeignKey(
                        name: "FK_ItemGroups_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ItemIngrediants = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ItemImage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ItemPrice = table.Column<int>(type: "int", nullable: true),
                    ItemGroupId = table.Column<int>(type: "int", nullable: false),
                    ItemSubGroupId = table.Column<int>(type: "int", nullable: true),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    MenuId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_ItemGroups_ItemGroupId",
                        column: x => x.ItemGroupId,
                        principalTable: "ItemGroups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_ItemGroups_ItemSubGroupId",
                        column: x => x.ItemSubGroupId,
                        principalTable: "ItemGroups",
                        principalColumn: "GroupId");
                    table.ForeignKey(
                        name: "FK_Items_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Menus_MenuId1",
                        column: x => x.MenuId1,
                        principalTable: "Menus",
                        principalColumn: "MenuId");
                });

            migrationBuilder.CreateTable(
                name: "ItemExteraConnections",
                columns: table => new
                {
                    IECId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ExteraItemId = table.Column<int>(type: "int", nullable: false),
                    ItemId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemExteraConnections", x => x.IECId);
                    table.ForeignKey(
                        name: "FK_ItemExteraConnections_ExteraItems_ExteraItemId",
                        column: x => x.ExteraItemId,
                        principalTable: "ExteraItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemExteraConnections_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemExteraConnections_Items_ItemId1",
                        column: x => x.ItemId1,
                        principalTable: "Items",
                        principalColumn: "ItemId");
                });

            migrationBuilder.CreateTable(
                name: "ItemModels",
                columns: table => new
                {
                    ItemModelId = table.Column<int>(type: "int", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemThisModelPrice = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemModels", x => x.ItemModelId);
                    table.ForeignKey(
                        name: "FK_ItemModels_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExteraItems_MenuId",
                table: "ExteraItems",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemExteraConnections_ExteraItemId",
                table: "ItemExteraConnections",
                column: "ExteraItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemExteraConnections_ItemId",
                table: "ItemExteraConnections",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemExteraConnections_ItemId1",
                table: "ItemExteraConnections",
                column: "ItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroups_MenuId",
                table: "ItemGroups",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroups_ParentId",
                table: "ItemGroups",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemModels_ItemId",
                table: "ItemModels",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemGroupId",
                table: "Items",
                column: "ItemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemSubGroupId",
                table: "Items",
                column: "ItemSubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_MenuId",
                table: "Items",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_MenuId1",
                table: "Items",
                column: "MenuId1");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_BranchId",
                table: "Menus",
                column: "BranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemExteraConnections");

            migrationBuilder.DropTable(
                name: "ItemModels");

            migrationBuilder.DropTable(
                name: "ExteraItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ItemGroups");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
