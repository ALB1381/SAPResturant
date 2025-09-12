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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;

                foreach (var property in entityType.GetProperties())
                {
                    // Example: Apply to all int primary keys
                    if (property.IsPrimaryKey() && property.ClrType == typeof(int))
                    {
                        modelBuilder.Entity(clrType)
                            .Property(property.Name)
                            .ValueGeneratedNever(); // Equivalent to DatabaseGeneratedOption.None
                    }
                }
            }
        }
    }
}
