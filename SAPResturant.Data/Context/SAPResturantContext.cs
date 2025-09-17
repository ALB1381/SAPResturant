using Microsoft.EntityFrameworkCore;
using SAPResturant.Data.Entities;
using SAPResturant.Data.Entities.Owners;
using SAPResturant.Data.Entities.Owners.Tickets;
using SAPResturant.Data.Entities.Resturants;
using SAPResturant.Data.Entities.Resturants.Members;
using SAPResturant.Data.Entities.Resturants.Members.Shiftings;
using SAPResturant.Data.Entities.Resturants.Menus;
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



        public DbSet<Owner> Owners { get; set; }
        public DbSet<OwnerNotification> OwnerNotifications { get; set; }
        public DbSet<OwnerTransaction> OwnerTransactions { get; set; }
        public DbSet<SubTransaction> SubTransactions { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchType> BranchTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Resturant> Resturants { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<DeleteHistory> DeleteHistories { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketCategory> TicketCategories { get; set; }
        public DbSet<TicketModel> TicketModels { get; set; }
        public DbSet<Shifting> Shiftings { get; set; }
        public DbSet<ArrivalDepartureHour> ArrivalDepartureHours { get; set; }
        public DbSet<Memeber> Memebers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<ExteraItem> ExteraItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemExteraConnection> ItemExteraConnections { get; set; }
        public DbSet<ItemGroup> ItemGroups { get; set; }
        public DbSet<ItemModel> ItemModels { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Table> Tables { get; set; }
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
            modelBuilder.Entity<ArrivalDepartureHour>()
           .HasOne(adh => adh.Memeber) // An ArrivalDepartureHour has one Memeber
           .WithMany() // A Memeber can have many ArrivalDepartureHour records (assuming no collection on Memeber side)
           .HasForeignKey(adh => adh.MemeberId)
           .OnDelete(DeleteBehavior.Restrict); // <-- This is the magic line!


            modelBuilder.Entity<Shifting>() // <-- Assuming your class is named 'Shifting'
        .HasOne(s => s.Memeber)   // <-- Assuming you have a 'Member' navigation property
        .WithMany()
        .HasForeignKey(s => s.MemberId)
        .OnDelete(DeleteBehavior.Restrict); // <-- This breaks the new cycle

            modelBuilder.Entity<Item>()
                .HasOne(adh => adh.Menu)
                .WithMany()
                .HasForeignKey(adh => adh.MenuId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemExteraConnection>()
                .HasOne(adh => adh.Item)
                .WithMany()
                .HasForeignKey(adh => adh.ItemId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<BranchType>().HasData(new BranchType() { BranchTypeId = 1, Type = "Cafe" }, new BranchType() { BranchTypeId = 2, Type = "Resturant" }, new BranchType() { BranchTypeId = 3, Type = "Cafe & Resturant" });
        }
    }
}
