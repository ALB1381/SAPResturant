using Microsoft.EntityFrameworkCore;
using SAPResturant.Data.Entities;
using SAPResturant.Data.Entities.Owners;
using SAPResturant.Data.Entities.Owners.Tickets;
using SAPResturant.Data.Entities.Resturants;
using SAPResturant.Data.Entities.Resturants.Members;
using SAPResturant.Data.Entities.Resturants.Members.Shiftings;
using SAPResturant.Data.Entities.Resturants.Menus;
using SAPResturant.Data.Entities.Resturants.Orders;
using SAPResturant.Data.Entities.Warehouse;
using SAPResturant.Data.Entities.Warehouse.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Data.Context
{
    public class SAPResturantContext : DbContext
    {
        public SAPResturantContext(DbContextOptions<SAPResturantContext> options) : base(options)
        {

        }




        #region Owners Ticket Tables
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketCategory> TicketCategories { get; set; }
        public DbSet<TicketModel> TicketModels { get; set; }
        #endregion




        #region Owner Tables
        public DbSet<Owner> Owners { get; set; }
        public DbSet<OwnerNotification> OwnerNotifications { get; set; }
        public DbSet<OwnerTransaction> OwnerTransactions { get; set; }
        public DbSet<SubTransaction> SubTransactions { get; set; }
        public DbSet<TransactionPaymentMethod> TransactionPaymentMethods { get; set; }
        #endregion




        #region Branch Employes Shift Tables
        public DbSet<PlanedShift> PlanedShifts { get; set; }
        public DbSet<Shifting> Shiftings { get; set; }
        #endregion




        #region Branch Employe or member Tables
        public DbSet<Memeber> Memebers { get; set; }
        #endregion



        #region Branch Menus Tables
        public DbSet<ExteraItem> ExteraOnItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemDiscount> ItemDiscounts { get; set; }
        public DbSet<ItemExteraConnection> ItemExteraConnections { get; set; }
        public DbSet<ItemGroup> ItemGroups { get; set; }
        public DbSet<ItemModel> ItemModels { get; set; }
        public DbSet<Menu> Menus { get; set; }
        #endregion




        #region Branch Orders and transaction
        public DbSet<IncomeCard> IncomeCards { get; set; }
        public DbSet<InnerOrder> InnerOrders { get; set; }
        public DbSet<OnlineOrder> OnlineOrders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Pose> Poses { get; set; }
        public DbSet<SubInnerOrder> SubInnerOrders { get; set; }
        public DbSet<SubOnlineOrder> SubOnlineOrders { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        #endregion

        #region Branch It Self
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchType> BranchTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerSex> CustomerSexes { get; set; }
        public DbSet<ResturanSection> ResturanSections { get; set; }
        public DbSet<Resturant> Resturants { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TableReservation> TableReservations { get; set; }
        public DbSet<TableReservationTableConnection> TableReservationTableConnections { get; set; }
        public DbSet<TableStatus> TableStatuses { get; set; }
        #endregion


        #region Were house tables
        public DbSet<ItemModelInventoryConnection> ItemModelInventoryConnections { get; set; }
        public DbSet<Exited> Exiteds { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryGroup> InventoryGroups { get; set; }
        public DbSet<InventoryStatus> InventoryStatuses { get; set; }
        public DbSet<Supplied> Supplieds { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //modelBuilder.Entity<BranchType>().HasData(new BranchType() { BranchTypeId = 1, Type = "Cafe" }, new BranchType() { BranchTypeId = 2, Type = "Resturant" }, new BranchType() { BranchTypeId = 3, Type = "Cafe & Resturant" });
        }
    }
}
