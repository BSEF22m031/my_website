using InventoryManagementDTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDAL
{

    public class InventoryManagementDbContext : DbContext
    {
        
            public DbSet<Product> Products { get; set; }
            public DbSet<Supplier> Suppliers { get; set; }
            public DbSet<InventoryTransaction> InventoryTransactions { get; set; }

        public InventoryManagementDbContext(DbContextOptions<InventoryManagementDbContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=InventoryDB;Integrated Security=True;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>()
                .HasIndex(s => s.SupplierName)
                .IsUnique(); 

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.ProductName)
                .IsUnique(); 

            modelBuilder.Entity<InventoryTransaction>()
                .Property(t => t.TransactionDate)
                .HasDefaultValueSql("GETUTCDATE()"); 

            base.OnModelCreating(modelBuilder);
        }


    }

}
