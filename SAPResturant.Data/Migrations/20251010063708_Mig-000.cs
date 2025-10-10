using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    AdminstratorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    BranchTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchTypes", x => x.BranchTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSexes",
                columns: table => new
                {
                    SexId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SexName = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSexes", x => x.SexId);
                });

            migrationBuilder.CreateTable(
                name: "InventoryGroups",
                columns: table => new
                {
                    InventoryGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
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
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryStatuses", x => x.InventoryStatusId);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    OrderStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Percent = table.Column<short>(type: "smallint", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.OrderStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OwnerPhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OwnerEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OwnerUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OwnerRegisterationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerPasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    OwnerPasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    OwnerEmailActiveCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    OwnerPhoneNumberActiveCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    LastEmailActiveCodeSent = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastPhoneNumberActiveCodeSent = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsEmailActive = table.Column<bool>(type: "bit", nullable: false),
                    IsPhoneNumberActive = table.Column<bool>(type: "bit", nullable: false),
                    IsOwnerActive = table.Column<bool>(type: "bit", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    MethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleOfPaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Free = table.Column<bool>(type: "bit", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.MethodId);
                });

            migrationBuilder.CreateTable(
                name: "TableStatuses",
                columns: table => new
                {
                    TableStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableStatusName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableStatuses", x => x.TableStatusId);
                });

            migrationBuilder.CreateTable(
                name: "TicketCategories",
                columns: table => new
                {
                    TicketCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketCategoryText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketCategories", x => x.TicketCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "TicketModels",
                columns: table => new
                {
                    TicketModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketModelText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketModels", x => x.TicketModelId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionPaymentMethods",
                columns: table => new
                {
                    MethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionPaymentMethods", x => x.MethodId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
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
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationReason = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NotificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeenDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerNotifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_OwnerNotifications_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resturants",
                columns: table => new
                {
                    ResturantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResturantName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MainResturantAddress = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    ResturantLogo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
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
                    TicketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketHeader = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TicketText = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    TicketTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WasItResponse = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    TicketModelId = table.Column<int>(type: "int", nullable: false),
                    TicketCategoryId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Tickets_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_Tickets_Tickets_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Tickets",
                        principalColumn: "TicketID");
                });

            migrationBuilder.CreateTable(
                name: "OwnerTransactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionPrice = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsPayed = table.Column<bool>(type: "bit", nullable: false),
                    PayedTiime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProofOfPaymentIfItNeeds = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    PayMethodId = table.Column<int>(type: "int", nullable: true),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
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
                    table.ForeignKey(
                        name: "FK_OwnerTransactions_TransactionPaymentMethods_PayMethodId",
                        column: x => x.PayMethodId,
                        principalTable: "TransactionPaymentMethods",
                        principalColumn: "MethodId");
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchAddress = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    IsBranchEnabledApplication = table.Column<bool>(type: "bit", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    BranchTypeId = table.Column<int>(type: "int", nullable: false),
                    ResturantId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
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
                        name: "FK_Branches_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_Branches_Resturants_ResturantId",
                        column: x => x.ResturantId,
                        principalTable: "Resturants",
                        principalColumn: "ResturantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubTransactions",
                columns: table => new
                {
                    SubTransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubTransactionPrice = table.Column<int>(type: "int", nullable: false),
                    SubTransactionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsPayed = table.Column<bool>(type: "bit", nullable: false),
                    SubTransactionPayedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubTransactionPlanedToPayTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProofOfPaymentIfItNeeds = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PayedMethodBuyId = table.Column<int>(type: "int", nullable: true),
                    OwnerTransactionId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
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
                    table.ForeignKey(
                        name: "FK_SubTransactions_TransactionPaymentMethods_PayedMethodBuyId",
                        column: x => x.PayedMethodBuyId,
                        principalTable: "TransactionPaymentMethods",
                        principalColumn: "MethodId");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InnerCustomerId = table.Column<int>(type: "int", nullable: false),
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
                    SexId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK_Customers_CustomerSexes_SexId",
                        column: x => x.SexId,
                        principalTable: "CustomerSexes",
                        principalColumn: "SexId");
                });

            migrationBuilder.CreateTable(
                name: "IncomeCards",
                columns: table => new
                {
                    IncomeCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CardInfo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeCards", x => x.IncomeCardId);
                    table.ForeignKey(
                        name: "FK_IncomeCards_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Memebers",
                columns: table => new
                {
                    MemeberId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserPasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserPasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserFullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CardId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BearthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndOfWorking = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memebers", x => x.MemeberId);
                    table.ForeignKey(
                        name: "FK_Memebers_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
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
                name: "Poses",
                columns: table => new
                {
                    PoseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoseName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poses", x => x.PoseId);
                    table.ForeignKey(
                        name: "FK_Poses_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResturanSections",
                columns: table => new
                {
                    SectionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionNumber = table.Column<int>(type: "int", nullable: false),
                    SectionDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResturanSections", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_ResturanSections_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SupplierDescription = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    SupplierPhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FirtSupply = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                    table.ForeignKey(
                        name: "FK_Suppliers_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnlineOrders",
                columns: table => new
                {
                    OuterOrderId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RawPrice = table.Column<int>(type: "int", nullable: false),
                    TaxPrice = table.Column<int>(type: "int", nullable: false),
                    SumPrice = table.Column<int>(type: "int", nullable: false),
                    DeliveryPrice = table.Column<int>(type: "int", nullable: false),
                    IsSnap = table.Column<bool>(type: "bit", nullable: false),
                    DeliveredAddress = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    OrderDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineOrders", x => x.OuterOrderId);
                    table.ForeignKey(
                        name: "FK_OnlineOrders_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnlineOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnlineOrders_OrderStatuses_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "OrderStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableReservations",
                columns: table => new
                {
                    ResevationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReservationDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableReservations", x => x.ResevationId);
                    table.ForeignKey(
                        name: "FK_TableReservations_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableReservations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanedShifts",
                columns: table => new
                {
                    PlanedShiftId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClockIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClockOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MemberId = table.Column<long>(type: "bigint", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanedShifts", x => x.PlanedShiftId);
                    table.ForeignKey(
                        name: "FK_PlanedShifts_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanedShifts_Memebers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Memebers",
                        principalColumn: "MemeberId");
                });

            migrationBuilder.CreateTable(
                name: "Shiftings",
                columns: table => new
                {
                    ShiftingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    MemberId = table.Column<long>(type: "bigint", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shiftings", x => x.ShiftingId);
                    table.ForeignKey(
                        name: "FK_Shiftings_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shiftings_Memebers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Memebers",
                        principalColumn: "MemeberId");
                });

            migrationBuilder.CreateTable(
                name: "ExteraOnItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExteraOnItemTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExtraOnItemDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: true),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExteraOnItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExteraOnItems_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExteraOnItems_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId");
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
                    MenuId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDiscounts", x => x.DisocuntId);
                    table.ForeignKey(
                        name: "FK_ItemDiscounts_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK_ItemDiscounts_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId");
                });

            migrationBuilder.CreateTable(
                name: "ItemGroups",
                columns: table => new
                {
                    GroupId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GroupBgColor = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    GroupTextColor = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    GroupCardColors = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: true),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemGroups", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_ItemGroups_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemGroups_ItemGroups_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ItemGroups",
                        principalColumn: "GroupId");
                    table.ForeignKey(
                        name: "FK_ItemGroups_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId");
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InventoryDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    InventoryUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ValueInStock = table.Column<int>(type: "int", nullable: true),
                    ChangeToNearToDoneValue = table.Column<int>(type: "int", nullable: true),
                    InventoryGroupId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<long>(type: "bigint", nullable: true),
                    InventoryStatusId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_Inventories_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ItemIngrediants = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ItemImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ItemGroupId = table.Column<long>(type: "bigint", nullable: true),
                    ItemSubGroupId = table.Column<long>(type: "bigint", nullable: true),
                    MenuId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_ItemGroups_ItemGroupId",
                        column: x => x.ItemGroupId,
                        principalTable: "ItemGroups",
                        principalColumn: "GroupId");
                    table.ForeignKey(
                        name: "FK_Items_ItemGroups_ItemSubGroupId",
                        column: x => x.ItemSubGroupId,
                        principalTable: "ItemGroups",
                        principalColumn: "GroupId");
                    table.ForeignKey(
                        name: "FK_Items_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId");
                });

            migrationBuilder.CreateTable(
                name: "Exiteds",
                columns: table => new
                {
                    ExitedId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExitedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitedValue = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InventoryId = table.Column<long>(type: "bigint", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exiteds", x => x.ExitedId);
                    table.ForeignKey(
                        name: "FK_Exiteds_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exiteds_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "InventoryId");
                });

            migrationBuilder.CreateTable(
                name: "Supplieds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuppliedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    SinglePrice = table.Column<int>(type: "int", nullable: true),
                    TotalPrice = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InventoryId = table.Column<long>(type: "bigint", nullable: true),
                    SupplierId = table.Column<long>(type: "bigint", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplieds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplieds_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supplieds_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "InventoryId");
                    table.ForeignKey(
                        name: "FK_Supplieds_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.CreateTable(
                name: "ItemExteraConnections",
                columns: table => new
                {
                    IECId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<long>(type: "bigint", nullable: true),
                    ExteraItemId = table.Column<long>(type: "bigint", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemExteraConnections", x => x.IECId);
                    table.ForeignKey(
                        name: "FK_ItemExteraConnections_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemExteraConnections_ExteraOnItems_ExteraItemId",
                        column: x => x.ExteraItemId,
                        principalTable: "ExteraOnItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemExteraConnections_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId");
                });

            migrationBuilder.CreateTable(
                name: "ItemModels",
                columns: table => new
                {
                    ItemModelId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemThisModelPrice = table.Column<int>(type: "int", nullable: false),
                    AvaibleCount = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<long>(type: "bigint", nullable: true),
                    DsicountId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    MenuId = table.Column<int>(type: "int", nullable: true),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemModels", x => x.ItemModelId);
                    table.ForeignKey(
                        name: "FK_ItemModels_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK_ItemModels_ItemDiscounts_DsicountId",
                        column: x => x.DsicountId,
                        principalTable: "ItemDiscounts",
                        principalColumn: "DisocuntId");
                    table.ForeignKey(
                        name: "FK_ItemModels_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId");
                    table.ForeignKey(
                        name: "FK_ItemModels_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId");
                });

            migrationBuilder.CreateTable(
                name: "ItemModelInventoryConnections",
                columns: table => new
                {
                    ConnectionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryId = table.Column<long>(type: "bigint", nullable: true),
                    ItemCaseId = table.Column<long>(type: "bigint", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemModelInventoryConnections", x => x.ConnectionId);
                    table.ForeignKey(
                        name: "FK_ItemModelInventoryConnections_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemModelInventoryConnections_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "InventoryId");
                    table.ForeignKey(
                        name: "FK_ItemModelInventoryConnections_ItemModels_ItemCaseId",
                        column: x => x.ItemCaseId,
                        principalTable: "ItemModels",
                        principalColumn: "ItemModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubOnlineOrders",
                columns: table => new
                {
                    SubOuterOrderId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(type: "int", nullable: false),
                    SinglePrice = table.Column<int>(type: "int", nullable: true),
                    SumPrice = table.Column<int>(type: "int", nullable: true),
                    MadeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CookedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemCaseID = table.Column<long>(type: "bigint", nullable: true),
                    ExtraOnItemId = table.Column<long>(type: "bigint", nullable: true),
                    OuterOrderId = table.Column<long>(type: "bigint", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubOnlineOrders", x => x.SubOuterOrderId);
                    table.ForeignKey(
                        name: "FK_SubOnlineOrders_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubOnlineOrders_ExteraOnItems_ExtraOnItemId",
                        column: x => x.ExtraOnItemId,
                        principalTable: "ExteraOnItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubOnlineOrders_ItemModels_ItemCaseID",
                        column: x => x.ItemCaseID,
                        principalTable: "ItemModels",
                        principalColumn: "ItemModelId");
                    table.ForeignKey(
                        name: "FK_SubOnlineOrders_OnlineOrders_OuterOrderId",
                        column: x => x.OuterOrderId,
                        principalTable: "OnlineOrders",
                        principalColumn: "OuterOrderId");
                });

            migrationBuilder.CreateTable(
                name: "InnerOrders",
                columns: table => new
                {
                    InnerOrderId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RawPrice = table.Column<int>(type: "int", nullable: false),
                    TaxPrice = table.Column<int>(type: "int", nullable: false),
                    SumPrice = table.Column<int>(type: "int", nullable: false),
                    OrderDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    OrderStatusId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: true),
                    TableId = table.Column<long>(type: "bigint", nullable: true),
                    MemberId = table.Column<long>(type: "bigint", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnerOrders", x => x.InnerOrderId);
                    table.ForeignKey(
                        name: "FK_InnerOrders_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InnerOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_InnerOrders_Memebers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Memebers",
                        principalColumn: "MemeberId");
                    table.ForeignKey(
                        name: "FK_InnerOrders_OrderStatuses_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "OrderStatusId");
                });

            migrationBuilder.CreateTable(
                name: "SubInnerOrders",
                columns: table => new
                {
                    SubInnerOrderId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(type: "int", nullable: false),
                    SinglePrice = table.Column<int>(type: "int", nullable: true),
                    SumPrice = table.Column<int>(type: "int", nullable: true),
                    MadeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CookedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveredTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemModelId = table.Column<long>(type: "bigint", nullable: true),
                    ExtraOnItemId = table.Column<long>(type: "bigint", nullable: true),
                    InnerOrderId = table.Column<long>(type: "bigint", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubInnerOrders", x => x.SubInnerOrderId);
                    table.ForeignKey(
                        name: "FK_SubInnerOrders_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubInnerOrders_ExteraOnItems_ExtraOnItemId",
                        column: x => x.ExtraOnItemId,
                        principalTable: "ExteraOnItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubInnerOrders_InnerOrders_InnerOrderId",
                        column: x => x.InnerOrderId,
                        principalTable: "InnerOrders",
                        principalColumn: "InnerOrderId");
                    table.ForeignKey(
                        name: "FK_SubInnerOrders_ItemModels_ItemModelId",
                        column: x => x.ItemModelId,
                        principalTable: "ItemModels",
                        principalColumn: "ItemModelId");
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    TableId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TableNumber = table.Column<int>(type: "int", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountOfSeats = table.Column<int>(type: "int", nullable: false),
                    PriceOfReservation = table.Column<int>(type: "int", nullable: true),
                    PeriodHourOfReservation = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    ResturantSectionId = table.Column<long>(type: "bigint", nullable: true),
                    TableStatusId = table.Column<int>(type: "int", nullable: true),
                    InnerOrderId = table.Column<long>(type: "bigint", nullable: true),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.TableId);
                    table.ForeignKey(
                        name: "FK_Tables_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tables_InnerOrders_InnerOrderId",
                        column: x => x.InnerOrderId,
                        principalTable: "InnerOrders",
                        principalColumn: "InnerOrderId");
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
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionSum = table.Column<int>(type: "int", nullable: false),
                    TransactionCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionPayedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPayed = table.Column<bool>(type: "bit", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: true),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    IncomCardId = table.Column<int>(type: "int", nullable: true),
                    PoseId = table.Column<int>(type: "int", nullable: true),
                    TableReservationId = table.Column<long>(type: "bigint", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_IncomeCards_IncomCardId",
                        column: x => x.IncomCardId,
                        principalTable: "IncomeCards",
                        principalColumn: "IncomeCardId");
                    table.ForeignKey(
                        name: "FK_Transactions_InnerOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "InnerOrders",
                        principalColumn: "InnerOrderId");
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

            migrationBuilder.CreateTable(
                name: "TableReservationTableConnections",
                columns: table => new
                {
                    ConnectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableReservationId = table.Column<long>(type: "bigint", nullable: true),
                    TableId = table.Column<long>(type: "bigint", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    OnMadeLog = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableReservationTableConnections", x => x.ConnectionId);
                    table.ForeignKey(
                        name: "FK_TableReservationTableConnections_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableReservationTableConnections_TableReservations_TableReservationId",
                        column: x => x.TableReservationId,
                        principalTable: "TableReservations",
                        principalColumn: "ResevationId");
                    table.ForeignKey(
                        name: "FK_TableReservationTableConnections_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "TableId");
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
                name: "IX_Branches_CountryId",
                table: "Branches",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_ResturantId",
                table: "Branches",
                column: "ResturantId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BranchId",
                table: "Customers",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SexId",
                table: "Customers",
                column: "SexId");

            migrationBuilder.CreateIndex(
                name: "IX_Exiteds_BranchId",
                table: "Exiteds",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Exiteds_InventoryId",
                table: "Exiteds",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ExteraOnItems_BranchId",
                table: "ExteraOnItems",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ExteraOnItems_MenuId",
                table: "ExteraOnItems",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeCards_BranchId",
                table: "IncomeCards",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_InnerOrders_BranchId",
                table: "InnerOrders",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_InnerOrders_CustomerId",
                table: "InnerOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InnerOrders_MemberId",
                table: "InnerOrders",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_InnerOrders_OrderStatusId",
                table: "InnerOrders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_InnerOrders_TableId",
                table: "InnerOrders",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_BranchId",
                table: "Inventories",
                column: "BranchId");

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
                name: "IX_ItemDiscounts_BranchId",
                table: "ItemDiscounts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDiscounts_MenuId",
                table: "ItemDiscounts",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemExteraConnections_BranchId",
                table: "ItemExteraConnections",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemExteraConnections_ExteraItemId",
                table: "ItemExteraConnections",
                column: "ExteraItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemExteraConnections_ItemId",
                table: "ItemExteraConnections",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroups_BranchId",
                table: "ItemGroups",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroups_MenuId",
                table: "ItemGroups",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroups_ParentId",
                table: "ItemGroups",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemModelInventoryConnections_BranchId",
                table: "ItemModelInventoryConnections",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemModelInventoryConnections_InventoryId",
                table: "ItemModelInventoryConnections",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemModelInventoryConnections_ItemCaseId",
                table: "ItemModelInventoryConnections",
                column: "ItemCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemModels_BranchId",
                table: "ItemModels",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemModels_DsicountId",
                table: "ItemModels",
                column: "DsicountId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemModels_ItemId",
                table: "ItemModels",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemModels_MenuId",
                table: "ItemModels",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_BranchId",
                table: "Items",
                column: "BranchId");

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
                name: "IX_Memebers_BranchId",
                table: "Memebers",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_BranchId",
                table: "Menus",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineOrders_BranchId",
                table: "OnlineOrders",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineOrders_CustomerId",
                table: "OnlineOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineOrders_OrderStatusId",
                table: "OnlineOrders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerNotifications_OwnerId",
                table: "OwnerNotifications",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerTransactions_OwnerId",
                table: "OwnerTransactions",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerTransactions_PayMethodId",
                table: "OwnerTransactions",
                column: "PayMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanedShifts_BranchId",
                table: "PlanedShifts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanedShifts_MemberId",
                table: "PlanedShifts",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Poses_BranchId",
                table: "Poses",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ResturanSections_BranchId",
                table: "ResturanSections",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Resturants_OwnerId",
                table: "Resturants",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shiftings_BranchId",
                table: "Shiftings",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Shiftings_MemberId",
                table: "Shiftings",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_SubInnerOrders_BranchId",
                table: "SubInnerOrders",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SubInnerOrders_ExtraOnItemId",
                table: "SubInnerOrders",
                column: "ExtraOnItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SubInnerOrders_InnerOrderId",
                table: "SubInnerOrders",
                column: "InnerOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SubInnerOrders_ItemModelId",
                table: "SubInnerOrders",
                column: "ItemModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SubOnlineOrders_BranchId",
                table: "SubOnlineOrders",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SubOnlineOrders_ExtraOnItemId",
                table: "SubOnlineOrders",
                column: "ExtraOnItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SubOnlineOrders_ItemCaseID",
                table: "SubOnlineOrders",
                column: "ItemCaseID");

            migrationBuilder.CreateIndex(
                name: "IX_SubOnlineOrders_OuterOrderId",
                table: "SubOnlineOrders",
                column: "OuterOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTransactions_OwnerTransactionId",
                table: "SubTransactions",
                column: "OwnerTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubTransactions_PayedMethodBuyId",
                table: "SubTransactions",
                column: "PayedMethodBuyId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplieds_BranchId",
                table: "Supplieds",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplieds_InventoryId",
                table: "Supplieds",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplieds_SupplierId",
                table: "Supplieds",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_BranchId",
                table: "Suppliers",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_TableReservations_BranchId",
                table: "TableReservations",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_TableReservations_CustomerId",
                table: "TableReservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TableReservationTableConnections_BranchId",
                table: "TableReservationTableConnections",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_TableReservationTableConnections_TableId",
                table: "TableReservationTableConnections",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_TableReservationTableConnections_TableReservationId",
                table: "TableReservationTableConnections",
                column: "TableReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_BranchId",
                table: "Tables",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_InnerOrderId",
                table: "Tables",
                column: "InnerOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_ResturantSectionId",
                table: "Tables",
                column: "ResturantSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_TableStatusId",
                table: "Tables",
                column: "TableStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OwnerId",
                table: "Tickets",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ParentId",
                table: "Tickets",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketCategoryId",
                table: "Tickets",
                column: "TicketCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketModelId",
                table: "Tickets",
                column: "TicketModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BranchId",
                table: "Transactions",
                column: "BranchId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_InnerOrders_Tables_TableId",
                table: "InnerOrders",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "TableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_BranchTypes_BranchTypeId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Cities_CityId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Countries_CountryId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Resturants_ResturantId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Branches_BranchId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_InnerOrders_Branches_BranchId",
                table: "InnerOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Memebers_Branches_BranchId",
                table: "Memebers");

            migrationBuilder.DropForeignKey(
                name: "FK_ResturanSections_Branches_BranchId",
                table: "ResturanSections");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Branches_BranchId",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerSexes_SexId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_InnerOrders_Customers_CustomerId",
                table: "InnerOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_InnerOrders_Memebers_MemberId",
                table: "InnerOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_InnerOrders_OrderStatuses_OrderStatusId",
                table: "InnerOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_InnerOrders_Tables_TableId",
                table: "InnerOrders");

            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "Exiteds");

            migrationBuilder.DropTable(
                name: "ItemExteraConnections");

            migrationBuilder.DropTable(
                name: "ItemModelInventoryConnections");

            migrationBuilder.DropTable(
                name: "OwnerNotifications");

            migrationBuilder.DropTable(
                name: "PlanedShifts");

            migrationBuilder.DropTable(
                name: "Shiftings");

            migrationBuilder.DropTable(
                name: "SubInnerOrders");

            migrationBuilder.DropTable(
                name: "SubOnlineOrders");

            migrationBuilder.DropTable(
                name: "SubTransactions");

            migrationBuilder.DropTable(
                name: "Supplieds");

            migrationBuilder.DropTable(
                name: "TableReservationTableConnections");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "ExteraOnItems");

            migrationBuilder.DropTable(
                name: "ItemModels");

            migrationBuilder.DropTable(
                name: "OnlineOrders");

            migrationBuilder.DropTable(
                name: "OwnerTransactions");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "TicketCategories");

            migrationBuilder.DropTable(
                name: "TicketModels");

            migrationBuilder.DropTable(
                name: "IncomeCards");

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
                name: "TransactionPaymentMethods");

            migrationBuilder.DropTable(
                name: "InventoryGroups");

            migrationBuilder.DropTable(
                name: "InventoryStatuses");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "ItemGroups");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "BranchTypes");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Resturants");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "CustomerSexes");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Memebers");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "InnerOrders");

            migrationBuilder.DropTable(
                name: "ResturanSections");

            migrationBuilder.DropTable(
                name: "TableStatuses");
        }
    }
}
