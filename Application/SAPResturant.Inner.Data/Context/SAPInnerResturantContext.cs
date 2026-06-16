using Microsoft.EntityFrameworkCore;
using SAPResturant.Inner.Data.Entities.Customers;
using SAPResturant.Inner.Data.Entities.Menus;
using SAPResturant.Inner.Data.Entities.Menus.Connections;
using SAPResturant.Inner.Data.Entities.Orders;
using SAPResturant.Inner.Data.Entities.Orders.Discount;
using SAPResturant.Inner.Data.Entities.Orders.Space;
using SAPResturant.Inner.Data.Entities.Orders.Space.Connection;
using SAPResturant.Inner.Data.Entities.Users;
using SAPResturant.Inner.Data.Entities.Warehouse;
using SAPResturant.Inner.Data.Entities.Warehouse.Connection;

namespace SAPResturant.Inner.Data.Context
{
    public class SAPInnerResturantContext : DbContext
    {
        public SAPInnerResturantContext(DbContextOptions<SAPInnerResturantContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ExtraOnItemItemConnection> ExtraOnItemItemConnections { get; set; }
        public DbSet<ExtraOnItem> ExtraOnItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCase> ItemCases { get; set; }
        public DbSet<ItemGroup> ItemGroups { get; set; }
        public DbSet<ItemDiscount> ItemDiscounts { get; set; }
        public DbSet<TableReservationTableConnection> TableReservationTableConnections { get; set; }
        public DbSet<ResturanSection> ResturanSections { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TableReservation> TableReservations { get; set; }
        public DbSet<TableStatus> TableStatuses { get; set; }
        public DbSet<IncomeCard> IncomeCards { get; set; }
        public DbSet<InnerOrder> InnerOrders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OuterOrder> OuterOrders { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Pose> Poses { get; set; }
        public DbSet<SubInnerOrder> SubInnerOrders { get; set; }
        public DbSet<SubOuterOrder> SubOuterOrders { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PlanedShift> PlanedShifts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermissionConnection> RolePermissionConnections { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ItemCaseInventoryConnection> ItemCaseInventoryConnections { get; set; }
        public DbSet<Exited> Exiteds { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryGroup> InventoryGroups { get; set; }
        public DbSet<InventoryStatus> InventoryStatuses { get; set; }
        public DbSet<Supplied> Supplieds { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Always good practice to call the base method

            string log = "SystemSeed";
            modelBuilder.Entity<Table>().HasData(
                new Table() {CountOfSeats = 8, MaderLog = log, TableDescription ="Something to describe it",TableId = 1,TableName= "Dragon",TableNumber=4},
                new Table() {CountOfSeats = 4, MaderLog = log, TableDescription ="Something to describe it",TableId = 2,TableName= "Crown",TableNumber=3}
                );
            modelBuilder.Entity<TableStatus>().HasData(
                new TableStatus() {MaderLog=log,TableStatusId=1,TableStatusName="Free"},
                new TableStatus() {MaderLog=log,TableStatusId=2,TableStatusName="Taken"},
                new TableStatus() {MaderLog=log,TableStatusId=3,TableStatusName="Reserved"}
                );

            // 1. Seed Item Groups
            modelBuilder.Entity<ItemGroup>().HasData(
                new ItemGroup { ItemGroupId = 1, GroupName = "Hot Coffee", MaderLog = log },
                new ItemGroup { ItemGroupId = 2, GroupName = "Cold Beverages", MaderLog = log },
                new ItemGroup { ItemGroupId = 3, GroupName = "Breakfast", MaderLog = log },
                new ItemGroup { ItemGroupId = 4, GroupName = "Sandwiches & Wraps", MaderLog = log },
                new ItemGroup { ItemGroupId = 5, GroupName = "Burgers", MaderLog = log },
                new ItemGroup { ItemGroupId = 6, GroupName = "Desserts", MaderLog = log }
            );
            modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus() {MaderLog=log,OrderStatusId=1,StatusName="Initialized",Percent=10 },
                new OrderStatus() {MaderLog=log,OrderStatusId=2,StatusName= "Sent to kitchen", Percent=30 },
                new OrderStatus() {MaderLog=log,OrderStatusId=3,StatusName="Cooking",Percent=60 },
                new OrderStatus() {MaderLog=log,OrderStatusId=4,StatusName="Delivered",Percent=100 }
                );
            // 2. Seed 40 Items
            modelBuilder.Entity<Item>().HasData(
                // Hot Coffee
                new Item { ItemId = 1, ItemName = "Espresso", ItemGroupId = 1, MaderLog = log },
                new Item { ItemId = 2, ItemName = "Double Espresso", ItemGroupId = 1, MaderLog = log },
                new Item { ItemId = 3, ItemName = "Americano", ItemGroupId = 1, MaderLog = log },
                new Item { ItemId = 4, ItemName = "Cappuccino", ItemGroupId = 1, MaderLog = log },
                new Item { ItemId = 5, ItemName = "Latte", ItemGroupId = 1, MaderLog = log },
                new Item { ItemId = 6, ItemName = "Mocha", ItemGroupId = 1, MaderLog = log },
                new Item { ItemId = 7, ItemName = "Macchiato", ItemGroupId = 1, MaderLog = log },
                new Item { ItemId = 8, ItemName = "Flat White", ItemGroupId = 1, MaderLog = log },
                new Item { ItemId = 9, ItemName = "Hot Chocolate", ItemGroupId = 1, MaderLog = log },
                new Item { ItemId = 10, ItemName = "Chai Tea Latte", ItemGroupId = 1, MaderLog = log },

                // Cold Beverages
                new Item { ItemId = 11, ItemName = "Iced Americano", ItemGroupId = 2, MaderLog = log },
                new Item { ItemId = 12, ItemName = "Iced Latte", ItemGroupId = 2, MaderLog = log },
                new Item { ItemId = 13, ItemName = "Cold Brew", ItemGroupId = 2, MaderLog = log },
                new Item { ItemId = 14, ItemName = "Frappuccino", ItemGroupId = 2, MaderLog = log },
                new Item { ItemId = 15, ItemName = "Iced Peach Tea", ItemGroupId = 2, MaderLog = log },
                new Item { ItemId = 16, ItemName = "Lemonade", ItemGroupId = 2, MaderLog = log },
                new Item { ItemId = 17, ItemName = "Fresh Orange Juice", ItemGroupId = 2, MaderLog = log },
                new Item { ItemId = 18, ItemName = "Mango Smoothie", ItemGroupId = 2, MaderLog = log },

                // Breakfast
                new Item { ItemId = 19, ItemName = "Classic Pancakes", ItemGroupId = 3, MaderLog = log },
                new Item { ItemId = 20, ItemName = "Belgian Waffle", ItemGroupId = 3, MaderLog = log },
                new Item { ItemId = 21, ItemName = "Avocado Toast", ItemGroupId = 3, MaderLog = log },
                new Item { ItemId = 22, ItemName = "Eggs Benedict", ItemGroupId = 3, MaderLog = log },
                new Item { ItemId = 23, ItemName = "Oatmeal Bowl", ItemGroupId = 3, MaderLog = log },
                new Item { ItemId = 24, ItemName = "Bagel with Cream Cheese", ItemGroupId = 3, MaderLog = log },

                // Sandwiches & Wraps
                new Item { ItemId = 25, ItemName = "Club Sandwich", ItemGroupId = 4, MaderLog = log },
                new Item { ItemId = 26, ItemName = "BLT Sandwich", ItemGroupId = 4, MaderLog = log },
                new Item { ItemId = 27, ItemName = "Grilled Cheese", ItemGroupId = 4, MaderLog = log },
                new Item { ItemId = 28, ItemName = "Tuna Salad Sandwich", ItemGroupId = 4, MaderLog = log },
                new Item { ItemId = 29, ItemName = "Chicken Caesar Wrap", ItemGroupId = 4, MaderLog = log },
                new Item { ItemId = 30, ItemName = "Veggie Wrap", ItemGroupId = 4, MaderLog = log },

                // Burgers
                new Item { ItemId = 31, ItemName = "Classic Cheeseburger", ItemGroupId = 5, MaderLog = log },
                new Item { ItemId = 32, ItemName = "Bacon Burger", ItemGroupId = 5, MaderLog = log },
                new Item { ItemId = 33, ItemName = "Mushroom Swiss Burger", ItemGroupId = 5, MaderLog = log },
                new Item { ItemId = 34, ItemName = "Crispy Chicken Burger", ItemGroupId = 5, MaderLog = log },
                new Item { ItemId = 35, ItemName = "Spicy Black Bean Burger", ItemGroupId = 5, MaderLog = log },

                // Desserts
                new Item { ItemId = 36, ItemName = "New York Cheesecake", ItemGroupId = 6, MaderLog = log },
                new Item { ItemId = 37, ItemName = "Chocolate Fudge Cake", ItemGroupId = 6, MaderLog = log },
                new Item { ItemId = 38, ItemName = "Tiramisu", ItemGroupId = 6, MaderLog = log },
                new Item { ItemId = 39, ItemName = "Warm Brownie", ItemGroupId = 6, MaderLog = log },
                new Item { ItemId = 40, ItemName = "Ice Cream Sundae", ItemGroupId = 6, MaderLog = log }
            );

            // 3. Seed Item Cases (Prices for the items)
            var itemCases = new List<ItemCase>();
            for (int i = 1; i <= 40; i++)
            {
                int price = i <= 18 ? 5 : (i <= 35 ? 12 : 7); // Coffees: 5, Food: 12, Desserts: 7
                itemCases.Add(new ItemCase
                {
                    ItemCaseId = i,
                    ItemId = i,
                    CaseTitle = "Standard",
                    CasePrice = price,
                    MaderLog = log
                });
            }
            modelBuilder.Entity<ItemCase>().HasData(itemCases);

            // 4. Seed ExtraOnItems (Add-ons)
            modelBuilder.Entity<ExtraOnItem>().HasData(
                new ExtraOnItem { ExtraOnItemId = 1, ExtraOnItemTitle = "Extra Espresso Shot", ExtraOnItemPrice = 2, MaderLog = log },
                new ExtraOnItem { ExtraOnItemId = 2, ExtraOnItemTitle = "Oat Milk Alternative", ExtraOnItemPrice = 1, MaderLog = log },
                new ExtraOnItem { ExtraOnItemId = 3, ExtraOnItemTitle = "Add Bacon", ExtraOnItemPrice = 3, MaderLog = log },
                new ExtraOnItem { ExtraOnItemId = 4, ExtraOnItemTitle = "Extra Cheese", ExtraOnItemPrice = 2, MaderLog = log },
                new ExtraOnItem { ExtraOnItemId = 5, ExtraOnItemTitle = "Vanilla Syrup", ExtraOnItemPrice = 1, MaderLog = log }
            );

            // 5. Connect Extras to Specific Items
            modelBuilder.Entity<ExtraOnItemItemConnection>().HasData(
                // Extra Shot (1) connected to Latte (5), Cappuccino (4), Iced Latte (12)
                new ExtraOnItemItemConnection { ConnectionId = 1, ItemId = 5, ExtraOnItemId = 1, MaderLog = log },
                new ExtraOnItemItemConnection { ConnectionId = 2, ItemId = 4, ExtraOnItemId = 1, MaderLog = log },
                new ExtraOnItemItemConnection { ConnectionId = 3, ItemId = 12, ExtraOnItemId = 1, MaderLog = log },

                // Oat Milk (2) connected to Latte (5), Macchiato (7), Chai Tea Latte (10)
                new ExtraOnItemItemConnection { ConnectionId = 4, ItemId = 5, ExtraOnItemId = 2, MaderLog = log },
                new ExtraOnItemItemConnection { ConnectionId = 5, ItemId = 7, ExtraOnItemId = 2, MaderLog = log },
                new ExtraOnItemItemConnection { ConnectionId = 6, ItemId = 10, ExtraOnItemId = 2, MaderLog = log },

                // Add Bacon (3) connected to Classic Cheeseburger (31), Grilled Cheese (27), Pancakes (19)
                new ExtraOnItemItemConnection { ConnectionId = 7, ItemId = 31, ExtraOnItemId = 3, MaderLog = log },
                new ExtraOnItemItemConnection { ConnectionId = 8, ItemId = 27, ExtraOnItemId = 3, MaderLog = log },
                new ExtraOnItemItemConnection { ConnectionId = 9, ItemId = 19, ExtraOnItemId = 3, MaderLog = log },

                // Extra Cheese (4) connected to Cheeseburger (31), Omelette (Assuming Breakfast), Club Sandwich (25)
                new ExtraOnItemItemConnection { ConnectionId = 10, ItemId = 31, ExtraOnItemId = 4, MaderLog = log },
                new ExtraOnItemItemConnection { ConnectionId = 11, ItemId = 25, ExtraOnItemId = 4, MaderLog = log },

                // Vanilla Syrup (5) connected to Iced Latte (12), Frappuccino (14)
                new ExtraOnItemItemConnection { ConnectionId = 12, ItemId = 12, ExtraOnItemId = 5, MaderLog = log },
                new ExtraOnItemItemConnection { ConnectionId = 13, ItemId = 14, ExtraOnItemId = 5, MaderLog = log }
            );
        }
    }
}
