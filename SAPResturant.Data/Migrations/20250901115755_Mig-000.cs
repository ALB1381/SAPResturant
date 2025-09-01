using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SAPResturant.Data.Migrations
{
    /// <inheritdoc />
    public partial class Mig000 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    AdminstratorId = table.Column<int>(type: "int", nullable: false),
                    AdminstratorUserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdminstratorPasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdminstratorPasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.AdminstratorId);
                });

            migrationBuilder.CreateTable(
                name: "BranchTypes",
                columns: table => new
                {
                    BranchTypeId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchTypes", x => x.BranchTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "DeleteHistories",
                columns: table => new
                {
                    HistoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeletedRow = table.Column<int>(type: "int", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeleteHistories", x => x.HistoryId);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    LogId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WhateRole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Command = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WhichTable = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.LogId);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OwnerPhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OwnerEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OwnerUserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OwnerRegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerPasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    OwnerPasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsOwnerActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "TicketCategories",
                columns: table => new
                {
                    TicketCategoryId = table.Column<int>(type: "int", nullable: false),
                    TicketCategoryText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketCategories", x => x.TicketCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "TicketModels",
                columns: table => new
                {
                    TicketModelId = table.Column<int>(type: "int", nullable: false),
                    TicketModelText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketModels", x => x.TicketModelId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnerNotifications",
                columns: table => new
                {
                    NotidicationId = table.Column<int>(type: "int", nullable: false),
                    NotificationReason = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    NotificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerNotifications", x => x.NotidicationId);
                    table.ForeignKey(
                        name: "FK_OwnerNotifications_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnerTransactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    TransactionPrice = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsPayed = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerTransactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_OwnerTransactions_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resturants",
                columns: table => new
                {
                    ResturantId = table.Column<int>(type: "int", nullable: false),
                    ResturantName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MainResturantAddress = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resturants", x => x.ResturantId);
                    table.ForeignKey(
                        name: "FK_Resturants_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketID = table.Column<int>(type: "int", nullable: false),
                    TicketHeader = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TicketText = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    TicketModelId = table.Column<int>(type: "int", nullable: false),
                    TicketCategoryId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Tickets_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId");
                    table.ForeignKey(
                        name: "FK_Tickets_TicketCategories_TicketCategoryId",
                        column: x => x.TicketCategoryId,
                        principalTable: "TicketCategories",
                        principalColumn: "TicketCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketModels_TicketModelId",
                        column: x => x.TicketModelId,
                        principalTable: "TicketModels",
                        principalColumn: "TicketModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubTransactions",
                columns: table => new
                {
                    SubTransactionId = table.Column<int>(type: "int", nullable: false),
                    SubTransactionPrice = table.Column<int>(type: "int", nullable: false),
                    SubTransactionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsPayed = table.Column<bool>(type: "bit", nullable: false),
                    OwnerTransactionId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTransactions", x => x.SubTransactionId);
                    table.ForeignKey(
                        name: "FK_SubTransactions_OwnerTransactions_OwnerTransactionId",
                        column: x => x.OwnerTransactionId,
                        principalTable: "OwnerTransactions",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    SectionAddress = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    BranchTypeId = table.Column<int>(type: "int", nullable: false),
                    ResturantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                    table.ForeignKey(
                        name: "FK_Branches_BranchTypes_BranchTypeId",
                        column: x => x.BranchTypeId,
                        principalTable: "BranchTypes",
                        principalColumn: "BranchTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Branches_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Branches_Resturants_ResturantId",
                        column: x => x.ResturantId,
                        principalTable: "Resturants",
                        principalColumn: "ResturantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BranchTypes",
                columns: new[] { "BranchTypeId", "Type" },
                values: new object[,]
                {
                    { 1, "Cafe" },
                    { 2, "Resturant" },
                    { 3, "Cafe & Resturant" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_BranchTypeId",
                table: "Branches",
                column: "BranchTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CityId",
                table: "Branches",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_ResturantId",
                table: "Branches",
                column: "ResturantId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerNotifications_OwnerId",
                table: "OwnerNotifications",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerTransactions_OwnerId",
                table: "OwnerTransactions",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Resturants_OwnerId",
                table: "Resturants",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTransactions_OwnerTransactionId",
                table: "SubTransactions",
                column: "OwnerTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OwnerId",
                table: "Tickets",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketCategoryId",
                table: "Tickets",
                column: "TicketCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketModelId",
                table: "Tickets",
                column: "TicketModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "DeleteHistories");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "OwnerNotifications");

            migrationBuilder.DropTable(
                name: "SubTransactions");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "BranchTypes");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Resturants");

            migrationBuilder.DropTable(
                name: "OwnerTransactions");

            migrationBuilder.DropTable(
                name: "TicketCategories");

            migrationBuilder.DropTable(
                name: "TicketModels");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
