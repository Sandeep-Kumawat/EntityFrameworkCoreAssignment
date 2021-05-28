using DepartmentalStoreAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStoreAppAPI.Persistence
{
    public class DepartmentalStoreContext : DbContext
    {
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<ProductDetail> ProductDetail { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<StaffRole> StaffRole { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductSupplier> ProductSupplier { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host = localhost; Database = DepartmentalStoreApp ; Username = postgres; Password = Pass@123");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DepartmentalStoreContext).Assembly);
        }
    }
}
