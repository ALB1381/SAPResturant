using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAPResturant.Inner.Data.Migrations
{
    /// <inheritdoc />
    public partial class Mig000 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CustomerPhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Age = table.Column<byte>(type: "TINYINT", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true),
                    FirstShop = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmailActiveCode = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    EmailActiveSentCodeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsEmailActivated = table.Column<bool>(type: "bit", nullable: false),
                    IsPhoneNumberValidated = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumberActiveCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    PhoneNumberActiveSentCodeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsMan = table.Column<bool>(type: "bit", nullable: false),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "ExtraOnItems",
                columns: table => new
                {
                    ExtraOnItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtraOnItemTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExtraOnItemDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExtraOnItemPrice = table.Column<int>(type: "int", nullable: true),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraOnItems", x => x.ExtraOnItemId);
                });

            migrationBuilder.CreateTable(
                name: "IncomeCards",
                columns: table => new
                {
                    IncomeCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CardName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeCards", x => x.IncomeCardId);
                });

            migrationBuilder.CreateTable(
                name: "InventoryGroups",
                columns: table => new
                {
                    InventoryGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryGroups", x => x.InventoryGroupId);
                });

            migrationBuilder.CreateTable(
                name: "InventoryStatuses",
                columns: table => new
                {
                    InventoryStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    StatusColor = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryStatuses", x => x.InventoryStatusId);
                });

            migrationBuilder.CreateTable(
                name: "ItemDiscounts",
                columns: table => new
                {
                    DisocuntId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvaibleCount = table.Column<short>(type: "smallint", nullable: true),
                    DiscountPercent = table.Column<short>(type: "smallint", nullable: false),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDiscounts", x => x.DisocuntId);
                });

            migrationBuilder.CreateTable(
                name: "ItemGroups",
                columns: table => new
                {
                    ItemGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GroupBgColor = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    GroupTextColor = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    GroupCardColors = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemGroups", x => x.ItemGroupId);
                    table.ForeignKey(
                        name: "FK_ItemGroups_ItemGroups_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ItemGroups",
                        principalColumn: "ItemGroupId");
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    OrderStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Percent = table.Column<short>(type: "smallint", nullable: false),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.OrderStatusId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    MethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleOfPaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Free = table.Column<bool>(type: "bit", nullable: false),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.MethodId);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionTitle = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionId);
                });

            migrationBuilder.CreateTable(
                name: "Poses",
                columns: table => new
                {
                    PoseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoseName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poses", x => x.PoseId);
                });

            migrationBuilder.CreateTable(
                name: "ResturanSections",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionNumber = table.Column<int>(type: "int", nullable: false),
                    SectionDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResturanSections", x => x.SectionId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SupplierDescription = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    SupplierPhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FirtSupply = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "TableStatuses",
                columns: table => new
                {
                    TableStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableStatusName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableStatuses", x => x.TableStatusId);
                });

            migrationBuilder.CreateTable(
                name: "TableReservations",
                columns: table => new
                {
                    ResevationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReservationDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableReservations", x => x.ResevationId);
                    table.ForeignKey(
                        name: "FK_TableReservations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ItemIngrediants = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ItemImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ItemGroupId = table.Column<int>(type: "int", nullable: false),
                    ItemSubGroupId = table.Column<int>(type: "int", nullable: true),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_ItemGroups_ItemGroupId",
                        column: x => x.ItemGroupId,
                        principalTable: "ItemGroups",
                        principalColumn: "ItemGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_ItemGroups_ItemSubGroupId",
                        column: x => x.ItemSubGroupId,
                        principalTable: "ItemGroups",
                        principalColumn: "ItemGroupId");
                });

            migrationBuilder.CreateTable(
                name: "OuterOrders",
                columns: table => new
                {
                    OuterOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RawPrice = table.Column<int>(type: "int", nullable: false),
                    TaxPrice = table.Column<int>(type: "int", nullable: false),
                    SumPrice = table.Column<int>(type: "int", nullable: false),
                    DeliveryPrice = table.Column<int>(type: "int", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    OredeDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DeliveredAddress = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    IsSnap = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OuterOrders", x => x.OuterOrderId);
                    table.ForeignKey(
                        name: "FK_OuterOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OuterOrders_OrderStatuses_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "OrderStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissionConnections",
                columns: table => new
                {
                    ConnectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissionConnections", x => x.ConnectionId);
                    table.ForeignKey(
                        name: "FK_RolePermissionConnections_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissionConnections_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserPasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserPasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserFullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CardId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BearthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndOfWorking = table.Column<DateOnly>(type: "date", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InventoryDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    InventoryUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ValueInStock = table.Column<int>(type: "int", nullable: true),
                    ChangeToNearToDoneValue = table.Column<int>(type: "int", nullable: true),
                    InventoryGroupId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    InventoryStatusId = table.Column<int>(type: "int", nullable: true),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_Inventories_InventoryGroups_InventoryGroupId",
                        column: x => x.InventoryGroupId,
                        principalTable: "InventoryGroups",
                        principalColumn: "InventoryGroupId");
                    table.ForeignKey(
                        name: "FK_Inventories_InventoryStatuses_InventoryStatusId",
                        column: x => x.InventoryStatusId,
                        principalTable: "InventoryStatuses",
                        principalColumn: "InventoryStatusId");
                    table.ForeignKey(
                        name: "FK_Inventories_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    TableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TableNumber = table.Column<int>(type: "int", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountOfSeats = table.Column<int>(type: "int", nullable: false),
                    PriceOfReservation = table.Column<int>(type: "int", nullable: true),
                    PeriodHourOfReservation = table.Column<int>(type: "int", nullable: true),
                    ResturantSectionId = table.Column<int>(type: "int", nullable: true),
                    TableStatusId = table.Column<int>(type: "int", nullable: true),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.TableId);
                    table.ForeignKey(
                        name: "FK_Tables_ResturanSections_ResturantSectionId",
                        column: x => x.ResturantSectionId,
                        principalTable: "ResturanSections",
                        principalColumn: "SectionId");
                    table.ForeignKey(
                        name: "FK_Tables_TableStatuses_TableStatusId",
                        column: x => x.TableStatusId,
                        principalTable: "TableStatuses",
                        principalColumn: "TableStatusId");
                });

            migrationBuilder.CreateTable(
                name: "ExtraOnItemItemConnections",
                columns: table => new
                {
                    ConnectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ExtraOnItemId = table.Column<int>(type: "int", nullable: false),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraOnItemItemConnections", x => x.ConnectionId);
                    table.ForeignKey(
                        name: "FK_ExtraOnItemItemConnections_ExtraOnItems_ExtraOnItemId",
                        column: x => x.ExtraOnItemId,
                        principalTable: "ExtraOnItems",
                        principalColumn: "ExtraOnItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtraOnItemItemConnections_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemCases",
                columns: table => new
                {
                    ItemCaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CasePrice = table.Column<int>(type: "int", nullable: false),
                    AvaibleCount = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    DsicountId = table.Column<int>(type: "int", nullable: true),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCases", x => x.ItemCaseId);
                    table.ForeignKey(
                        name: "FK_ItemCases_ItemDiscounts_DsicountId",
                        column: x => x.DsicountId,
                        principalTable: "ItemDiscounts",
                        principalColumn: "DisocuntId");
                    table.ForeignKey(
                        name: "FK_ItemCases_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanedShifts",
                columns: table => new
                {
                    PlanedShiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClockIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClockOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanedShifts", x => x.PlanedShiftId);
                    table.ForeignKey(
                        name: "FK_PlanedShifts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    ShiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClockIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClockOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.ShiftId);
                    table.ForeignKey(
                        name: "FK_Shifts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exiteds",
                columns: table => new
                {
                    ExitedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExitedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitedValue = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exiteds", x => x.ExitedId);
                    table.ForeignKey(
                        name: "FK_Exiteds_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplieds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuppliedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    SinglePrice = table.Column<int>(type: "int", nullable: true),
                    TotalPrice = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplieds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplieds_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supplieds_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InnerOrders",
                columns: table => new
                {
                    InnerOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RawPrice = table.Column<int>(type: "int", nullable: false),
                    TaxPrice = table.Column<int>(type: "int", nullable: false),
                    SumPrice = table.Column<int>(type: "int", nullable: false),
                    OrderDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    OrderStatusId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    TableId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnerOrders", x => x.InnerOrderId);
                    table.ForeignKey(
                        name: "FK_InnerOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_InnerOrders_OrderStatuses_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "OrderStatusId");
                    table.ForeignKey(
                        name: "FK_InnerOrders_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "TableId");
                    table.ForeignKey(
                        name: "FK_InnerOrders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "TableReservationTableConnections",
                columns: table => new
                {
                    ConnectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableReservationId = table.Column<int>(type: "int", nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableReservationTableConnections", x => x.ConnectionId);
                    table.ForeignKey(
                        name: "FK_TableReservationTableConnections_TableReservations_TableReservationId",
                        column: x => x.TableReservationId,
                        principalTable: "TableReservations",
                        principalColumn: "ResevationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableReservationTableConnections_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "TableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemCaseInventoryConnections",
                columns: table => new
                {
                    ConnectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    ItemCaseId = table.Column<int>(type: "int", nullable: false),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCaseInventoryConnections", x => x.ConnectionId);
                    table.ForeignKey(
                        name: "FK_ItemCaseInventoryConnections_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemCaseInventoryConnections_ItemCases_ItemCaseId",
                        column: x => x.ItemCaseId,
                        principalTable: "ItemCases",
                        principalColumn: "ItemCaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubOuterOrders",
                columns: table => new
                {
                    SubOuterOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(type: "int", nullable: false),
                    SinglePrice = table.Column<int>(type: "int", nullable: true),
                    SumPrice = table.Column<int>(type: "int", nullable: true),
                    MadeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CookedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemCaseID = table.Column<int>(type: "int", nullable: true),
                    ExtraOnItemId = table.Column<int>(type: "int", nullable: true),
                    OuterOrderId = table.Column<int>(type: "int", nullable: false),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubOuterOrders", x => x.SubOuterOrderId);
                    table.ForeignKey(
                        name: "FK_SubOuterOrders_ExtraOnItems_ExtraOnItemId",
                        column: x => x.ExtraOnItemId,
                        principalTable: "ExtraOnItems",
                        principalColumn: "ExtraOnItemId");
                    table.ForeignKey(
                        name: "FK_SubOuterOrders_ItemCases_ItemCaseID",
                        column: x => x.ItemCaseID,
                        principalTable: "ItemCases",
                        principalColumn: "ItemCaseId");
                    table.ForeignKey(
                        name: "FK_SubOuterOrders_OuterOrders_OuterOrderId",
                        column: x => x.OuterOrderId,
                        principalTable: "OuterOrders",
                        principalColumn: "OuterOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubInnerOrders",
                columns: table => new
                {
                    SubInnerOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(type: "int", nullable: false),
                    SinglePrice = table.Column<int>(type: "int", nullable: true),
                    SumPrice = table.Column<int>(type: "int", nullable: true),
                    MadeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CookedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveredTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemCaseID = table.Column<int>(type: "int", nullable: true),
                    ExtraOnItemId = table.Column<int>(type: "int", nullable: true),
                    InnerOrderId = table.Column<int>(type: "int", nullable: false),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubInnerOrders", x => x.SubInnerOrderId);
                    table.ForeignKey(
                        name: "FK_SubInnerOrders_ExtraOnItems_ExtraOnItemId",
                        column: x => x.ExtraOnItemId,
                        principalTable: "ExtraOnItems",
                        principalColumn: "ExtraOnItemId");
                    table.ForeignKey(
                        name: "FK_SubInnerOrders_InnerOrders_InnerOrderId",
                        column: x => x.InnerOrderId,
                        principalTable: "InnerOrders",
                        principalColumn: "InnerOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubInnerOrders_ItemCases_ItemCaseID",
                        column: x => x.ItemCaseID,
                        principalTable: "ItemCases",
                        principalColumn: "ItemCaseId");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionSum = table.Column<int>(type: "int", nullable: false),
                    TransactionCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionPayedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    IncomCardId = table.Column<int>(type: "int", nullable: true),
                    PoseId = table.Column<int>(type: "int", nullable: true),
                    TableReservationId = table.Column<int>(type: "int", nullable: true),
                    IsPayed = table.Column<bool>(type: "bit", nullable: false),
                    MaderLog = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_IncomeCards_IncomCardId",
                        column: x => x.IncomCardId,
                        principalTable: "IncomeCards",
                        principalColumn: "IncomeCardId");
                    table.ForeignKey(
                        name: "FK_Transactions_InnerOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "InnerOrders",
                        principalColumn: "InnerOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "MethodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Poses_PoseId",
                        column: x => x.PoseId,
                        principalTable: "Poses",
                        principalColumn: "PoseId");
                    table.ForeignKey(
                        name: "FK_Transactions_TableReservations_TableReservationId",
                        column: x => x.TableReservationId,
                        principalTable: "TableReservations",
                        principalColumn: "ResevationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exiteds_InventoryId",
                table: "Exiteds",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraOnItemItemConnections_ExtraOnItemId",
                table: "ExtraOnItemItemConnections",
                column: "ExtraOnItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraOnItemItemConnections_ItemId",
                table: "ExtraOnItemItemConnections",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InnerOrders_CustomerId",
                table: "InnerOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InnerOrders_OrderStatusId",
                table: "InnerOrders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_InnerOrders_TableId",
                table: "InnerOrders",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_InnerOrders_UserId",
                table: "InnerOrders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_InventoryGroupId",
                table: "Inventories",
                column: "InventoryGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_InventoryStatusId",
                table: "Inventories",
                column: "InventoryStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_SupplierId",
                table: "Inventories",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCaseInventoryConnections_InventoryId",
                table: "ItemCaseInventoryConnections",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCaseInventoryConnections_ItemCaseId",
                table: "ItemCaseInventoryConnections",
                column: "ItemCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCases_DsicountId",
                table: "ItemCases",
                column: "DsicountId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCases_ItemId",
                table: "ItemCases",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroups_ParentId",
                table: "ItemGroups",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemGroupId",
                table: "Items",
                column: "ItemGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemSubGroupId",
                table: "Items",
                column: "ItemSubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_OuterOrders_CustomerId",
                table: "OuterOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OuterOrders_OrderStatusId",
                table: "OuterOrders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanedShifts_UserId",
                table: "PlanedShifts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionConnections_PermissionId",
                table: "RolePermissionConnections",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionConnections_RoleId",
                table: "RolePermissionConnections",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_UserId",
                table: "Shifts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubInnerOrders_ExtraOnItemId",
                table: "SubInnerOrders",
                column: "ExtraOnItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SubInnerOrders_InnerOrderId",
                table: "SubInnerOrders",
                column: "InnerOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SubInnerOrders_ItemCaseID",
                table: "SubInnerOrders",
                column: "ItemCaseID");

            migrationBuilder.CreateIndex(
                name: "IX_SubOuterOrders_ExtraOnItemId",
                table: "SubOuterOrders",
                column: "ExtraOnItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SubOuterOrders_ItemCaseID",
                table: "SubOuterOrders",
                column: "ItemCaseID");

            migrationBuilder.CreateIndex(
                name: "IX_SubOuterOrders_OuterOrderId",
                table: "SubOuterOrders",
                column: "OuterOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplieds_InventoryId",
                table: "Supplieds",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplieds_SupplierId",
                table: "Supplieds",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_TableReservations_CustomerId",
                table: "TableReservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TableReservationTableConnections_TableId",
                table: "TableReservationTableConnections",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_TableReservationTableConnections_TableReservationId",
                table: "TableReservationTableConnections",
                column: "TableReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_ResturantSectionId",
                table: "Tables",
                column: "ResturantSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_TableStatusId",
                table: "Tables",
                column: "TableStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_IncomCardId",
                table: "Transactions",
                column: "IncomCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_OrderId",
                table: "Transactions",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PaymentMethodId",
                table: "Transactions",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PoseId",
                table: "Transactions",
                column: "PoseId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TableReservationId",
                table: "Transactions",
                column: "TableReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exiteds");

            migrationBuilder.DropTable(
                name: "ExtraOnItemItemConnections");

            migrationBuilder.DropTable(
                name: "ItemCaseInventoryConnections");

            migrationBuilder.DropTable(
                name: "PlanedShifts");

            migrationBuilder.DropTable(
                name: "RolePermissionConnections");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "SubInnerOrders");

            migrationBuilder.DropTable(
                name: "SubOuterOrders");

            migrationBuilder.DropTable(
                name: "Supplieds");

            migrationBuilder.DropTable(
                name: "TableReservationTableConnections");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "ExtraOnItems");

            migrationBuilder.DropTable(
                name: "ItemCases");

            migrationBuilder.DropTable(
                name: "OuterOrders");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "IncomeCards");

            migrationBuilder.DropTable(
                name: "InnerOrders");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Poses");

            migrationBuilder.DropTable(
                name: "TableReservations");

            migrationBuilder.DropTable(
                name: "ItemDiscounts");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "InventoryGroups");

            migrationBuilder.DropTable(
                name: "InventoryStatuses");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ItemGroups");

            migrationBuilder.DropTable(
                name: "ResturanSections");

            migrationBuilder.DropTable(
                name: "TableStatuses");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
