using Microsoft.EntityFrameworkCore;
using SAPResturant.Data.Entities;
using SAPResturant.Data.Entities.Owners;
using SAPResturant.Data.Entities.Owners.Tickets;
using SAPResturant.Data.Entities.Resturants;
using SAPResturant.Data.Entities.Resturants.Members;
using SAPResturant.Data.Entities.Resturants.Members.Shiftings;
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
         .HasOne(a => a.Memeber)
         .WithMany()
         .HasForeignKey(a => a.MemeberId)
         .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction

            modelBuilder.Entity<ArrivalDepartureHour>()
                .HasOne(a => a.Branch)
                .WithMany()
                .HasForeignKey(a => a.BranchId)
                .OnDelete(DeleteBehavior.Cascade); // keep cascade only on one
            modelBuilder.Entity<BranchType>().HasData(new BranchType() { BranchTypeId = 1, Type = "Cafe" }, new BranchType() { BranchTypeId = 2, Type = "Resturant" }, new BranchType() { BranchTypeId = 3, Type = "Cafe & Resturant" });
        }
    }
}
