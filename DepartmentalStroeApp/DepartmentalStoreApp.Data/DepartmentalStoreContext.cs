using DepartmentalStoreApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStoreApp.Data
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
        public DbSet<ProductDetail> productDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseNpgsql(@"Host = localhost; Database =DepartmentalStoreApp ; Username = postgres; Password = Pass@123");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Adress Table
            modelBuilder.Entity<Address>().HasKey(s => s.AddressId);
            modelBuilder.Entity<Address>().Property(s => s.AddressLine1).HasMaxLength(128).IsRequired();
            modelBuilder.Entity<Address>().Property(s => s.AddressLine2).HasMaxLength(64).IsRequired();
            modelBuilder.Entity<Address>().Property(s => s.City).HasMaxLength(64).IsRequired();
            modelBuilder.Entity<Address>().Property(s => s.PostalCode).HasMaxLength(6).IsRequired();
            modelBuilder.Entity<Address>().Property(s => s.State).HasMaxLength(64).IsRequired();

            // StaffRole Table
            modelBuilder.Entity<StaffRole>().HasKey(s => s.StaffRoleId);
            modelBuilder.Entity<StaffRole>().HasMany(s => s.Staffs).WithOne(s => s.StaffRole);
            modelBuilder.Entity<StaffRole>().Property(s => s.RoleName).HasMaxLength(64).IsRequired();
            modelBuilder.Entity<StaffRole>().Property(s => s.Description).HasMaxLength(128).IsRequired();

            //Staff Table
            modelBuilder.Entity<Staff>().HasKey(s => s.StaffId);
            modelBuilder.Entity<Staff>().HasOne(s => s.Address).WithMany().HasForeignKey(s => s.AddressId);
            modelBuilder.Entity<Staff>().HasOne(s => s.StaffRole).WithMany(s=>s.Staffs).HasForeignKey(s => s.StaffRoleId);
            modelBuilder.Entity<Staff>().Property(s => s.FirstName).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Staff>().Property(s => s.LastName).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Staff>().Property(s => s.BirthDate).IsRequired();
            modelBuilder.Entity<Staff>().Property(s => s.Phone).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Staff>().Property(s => s.Salary).IsRequired();

            //Category Table
            modelBuilder.Entity<Category>().HasKey(s => s.CategoryId);
            modelBuilder.Entity<Category>().Property(s => s.CategoryName).HasMaxLength(64).IsRequired();
            modelBuilder.Entity<Category>().Property(s => s.CategoryCode).HasMaxLength(64).IsRequired();
            modelBuilder.Entity<Category>().Property(s => s.Description).HasMaxLength(128).IsRequired();

            // Product Table
            modelBuilder.Entity<Product>().HasKey(s => s.ProductId);
            modelBuilder.Entity<Product>().Property(s => s.ProductName).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Product>().Property(s => s.ProductCode).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Product>().Property(s => s.CurrentQuantity).IsRequired();
    

            //ProductCategory
            modelBuilder.Entity<ProductCategory>().HasKey(s => new { s.CategoryId, s.ProductId });

            //Product Detail Table
            modelBuilder.Entity<ProductDetail>().HasKey(s => s.ProductId);
            modelBuilder.Entity<ProductDetail>().HasOne(s => s.Product).WithOne(s => s.ProductDetail)
                .HasForeignKey<ProductDetail>(s => s.ProductId);
            modelBuilder.Entity<ProductDetail>().Property(s => s.CostPrice).IsRequired();
            modelBuilder.Entity<ProductDetail>().Property(s => s.SellingPrice).IsRequired();
            modelBuilder.Entity<ProductDetail>().Property(s => s.DateOfPrice).IsRequired();

            // Inventory Table
            modelBuilder.Entity<Inventory>().HasKey(s => s.InventoryId);
            modelBuilder.Entity<Inventory>().HasOne(s => s.Product).WithOne(s => s.Inventory)
                .HasForeignKey<Inventory>(s => s.ProductId);
            modelBuilder.Entity<Inventory>().Property(s => s.Quantity).IsRequired();
            modelBuilder.Entity<Inventory>().Property(s => s.InStocks).IsRequired();

            // Supplier Table
            modelBuilder.Entity<Supplier>().HasKey(s => s.SupplierId);
            modelBuilder.Entity<Supplier>().HasOne(s => s.Address).WithMany().HasForeignKey(s => s.AddressId);
            modelBuilder.Entity<Supplier>().Property(s => s.FirstName).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.LastName).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.PhoneNumber).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Supplier>().Property(s => s.Email).HasMaxLength(30).IsRequired();

            // Order Table
            modelBuilder.Entity<Order>().HasKey(s => s.OrderId);
            modelBuilder.Entity<Order>().HasOne(s => s.Supplier).WithMany().HasForeignKey(s => s.SupplierId);
            modelBuilder.Entity<Order>().Property(s => s.OrderDate).IsRequired();

            // Order Details
            modelBuilder.Entity<OrderDetail>().HasKey(s => s.OrderId);
            modelBuilder.Entity<OrderDetail>().HasOne(s => s.Order).WithOne(s => s.OrderDetail)
                .HasForeignKey<OrderDetail>(s => s.OrderId);
            modelBuilder.Entity<OrderDetail>().HasOne(s => s.Product).WithMany()
                .HasForeignKey(s => s.ProductId);
            modelBuilder.Entity<OrderDetail>().Property(s => s.Quantity).IsRequired();
            modelBuilder.Entity<OrderDetail>().Property(s => s.UnitPrice).IsRequired();

        }
    }
}
