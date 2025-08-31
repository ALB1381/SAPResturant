using Microsoft.EntityFrameworkCore;
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
