using DepartmentalStoreApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DepartmentalStoreApp.ConsoleApp
{
    public class DatabaseOperation
    {
        public static DepartmentalStoreContext context = new DepartmentalStoreContext();
        public static void StaffQuery()
        {
            var staff = context.Staff.Include(s => s.StaffRole).Where(s => s.FirstName == "Sandeep").ToList();

            foreach (var i in staff)
            {
                Console.WriteLine($"{i.FirstName} {i.LastName}  {i.Phone} {i.Salary} {i.StaffRole.RoleName}");
            }
            var staff1 = context.Staff.Include(s => s.StaffRole).Where(s => s.Phone == "9887729448").ToList();

            foreach (var i in staff1)
            {
                Console.WriteLine($"{i.FirstName} {i.LastName}  {i.Phone} {i.Salary} {i.StaffRole.RoleName}");
            }
            var staff2 = context.Staff.Include(s => s.StaffRole).Where(s => s.FirstName == "Sandeep" && s.Phone == "9887729448").ToList();

            foreach (var i in staff2)
            {
                Console.WriteLine($"{i.FirstName} {i.LastName}  {i.Phone} {i.Salary} {i.StaffRole.RoleName}");
            }

        }
        public static void StaffRoleQuery()
        {
            var staff = context.StaffRole.Include(s =>s.Staffs).Where(s => s.RoleName == "Cashier").ToList();
            foreach (var i in staff)
            {
                foreach(var j in i.Staffs)
                {
                    Console.WriteLine($"{j.FirstName} {j.LastName}  {j.Phone} {j.Salary} {i.RoleName}");
                }
            }
        }
        public static void ProductQuery()
        {
            var product = context.Product.Where(s => s.ProductName == "Laptop").ToList();
            foreach (var i in product)
            {
                Console.WriteLine($"{i.ProductId} {i.ProductName} {i.ProductCode} {i.CurrentQuantity}");
            }

            var pro = context.Product.Include(s => s.ProductCategories).ThenInclude(s => s.Category)
                .Where(s => s.ProductCategories.Any(c => c.Category.CategoryName == "Shopping Goods")).ToList();
            foreach (var i in pro)
            {
                Console.WriteLine($"{i.ProductId} {i.ProductName} {i.ProductCode} {i.CurrentQuantity} {i.ProductCategories[0].Category.CategoryName}");
            }
            var pro1 = context.Product.Include(s => s.Inventory).Where(s => s.Inventory.InStocks == true).ToList();
            foreach (var i in pro1)
            {
                Console.WriteLine($"{i.ProductId} {i.ProductName} {i.ProductCode} {i.CurrentQuantity}");
            }
            var pro2 = context.Product.Include(s => s.Inventory).Where(s => s.Inventory.InStocks == false).ToList();
            foreach (var i in pro2)
            {
                Console.WriteLine($"{i.ProductId} {i.ProductName} {i.ProductCode} {i.CurrentQuantity}");
            }
            var pro3 = context.Product.Include(s => s.ProductDetail).Where(s => s.ProductDetail.SellingPrice > 100).ToList();
            foreach (var i in pro3)
            {
                Console.WriteLine($"{i.ProductId} {i.ProductName} {i.ProductCode} {i.ProductDetail.SellingPrice}");
            }
            var pro4 = context.Product.Include(s => s.ProductDetail).Where(s => s.ProductDetail.SellingPrice < 20000).ToList();
            foreach (var i in pro4)
            {
                Console.WriteLine($"{i.ProductId} {i.ProductName} {i.ProductCode} {i.ProductDetail.SellingPrice}");
            }
            var pro5 = context.Product.Include(s => s.ProductDetail).Where(s => s.ProductDetail.SellingPrice > 100 && s.ProductDetail.SellingPrice <6000).ToList();
            foreach (var i in pro5)
            {
                Console.WriteLine($"{i.ProductId} {i.ProductName} {i.ProductCode} {i.ProductDetail.SellingPrice}");
            }
        }
        public static void ProductQueryWithStock()
        {
            var pro = context.Product.Include(s => s.Inventory).Where(s => s.Inventory.InStocks == false).ToList();
            foreach (var i in pro)
            {
                Console.WriteLine($"{i.ProductId} {i.ProductName} {i.ProductCode} {i.CurrentQuantity}");
            }
        }
        public static void ProductCountInCategory()
        {
            var pro = context.Category.Include(s => s.ProductCategories)
                .Select(s => new { s.CategoryName, s.ProductCategories.Count }).ToList();
            foreach(var i in pro)
            {
                Console.WriteLine($"{i.CategoryName} {i.Count}");
            }
        }
        public static void ProductCountInCategoryInDesc()
        {
            var pro = context.Category.Include(s => s.ProductCategories)
               .Select(s => new { s.CategoryName, s.ProductCategories.Count }).OrderByDescending(s=>s.Count).ToList();
            foreach (var i in pro)
            {
                Console.WriteLine($"{i.CategoryName} {i.Count}");
            }
        }
        public static void SupplierQuery()
        {
            var sup = context.Supplier.Where(s => s.FirstName == "Rohan").ToList();
            foreach (var i in sup)
            {
                Console.WriteLine($"{i.FirstName} {i.LastName} {i.PhoneNumber} {i.Email}");
            }

            var sup1 = context.Supplier.Where(s => s.PhoneNumber == "23243456").ToList();
            foreach (var i in sup1)
            {
                Console.WriteLine($"{i.FirstName} {i.LastName} {i.PhoneNumber} {i.Email}");
            }


            var sup2 = context.Supplier.Where(s => s.Email == "gopal@gmail.com").ToList();
            foreach (var i in sup2)
            {
                Console.WriteLine($"{i.FirstName} {i.LastName} {i.PhoneNumber} {i.Email}");
            }

            var sup3 = context.Supplier.Include(s => s.Address).Where(s => s.Address.City == "Sikar").ToList();
            foreach (var i in sup3)
            {
                Console.WriteLine($"{i.FirstName} {i.LastName} {i.PhoneNumber} {i.Email}");
            }


            var sup4 = context.Supplier.Include(s => s.Address).Where(s => s.Address.City == "Noida").ToList();
            foreach (var i in sup4)
            {
                Console.WriteLine($"{i.FirstName} {i.LastName} {i.PhoneNumber} {i.Email}");
            }
        }
        public static void ProductSupplierQuery()
        {
            var product = context.Order.Include(x => x.OrderDetail)
                .ThenInclude(x => x.Product)
                .Include(x => x.Supplier)
                .Where(s => s.OrderDetail.Product.ProductName == "Laptop").ToList();
            foreach (var i in product)
            {
                Console.WriteLine($"{i.OrderId} {i.OrderDate} {i.OrderDetail.Quantity} {i.OrderDetail.UnitPrice}" +
                    $"{i.Supplier.FirstName} {i.Supplier.LastName}");
            }


            var product1 = context.Order.Include(x => x.OrderDetail)
                .ThenInclude(x => x.Product)
                .Include(x => x.Supplier)
                .Where(s => s.Supplier.FirstName == "Vikas").ToList();
            foreach (var i in product1)
            {
                Console.WriteLine($"{i.OrderId} {i.OrderDate} {i.OrderDetail.Quantity} {i.OrderDetail.UnitPrice}" +
                    $"{i.Supplier.FirstName}  {i.Supplier.LastName}");
            }


            var product2 = context.Order.Include(x => x.OrderDetail)
               .ThenInclude(x => x.Product)
               .Include(x => x.Supplier)
               .Where(s => s.OrderDetail.Product.ProductCode == "Pen").ToList();
            foreach (var i in product2)
            {
                Console.WriteLine($"{i.OrderId} {i.OrderDate} {i.OrderDetail.Quantity} {i.OrderDetail.UnitPrice}" +
                    $"{i.Supplier.FirstName}  {i.Supplier.LastName}");
            }


            var product3 = context.Order.Include(x => x.OrderDetail)
              .ThenInclude(x => x.Product)
              .Include(x => x.Supplier)
              .Where(s => s.OrderDetail.Order.OrderDate > new DateTime(2015, 12, 12)).ToList();
            foreach (var i in product3)
            {
                Console.WriteLine($"{i.OrderId} {i.OrderDate} {i.OrderDetail.Quantity} {i.OrderDetail.UnitPrice}" +
                    $"{i.Supplier.FirstName}  {i.Supplier.LastName}");
            }


            var product4 = context.Order.Include(x => x.OrderDetail)
              .ThenInclude(x => x.Product)
              .Include(x => x.Supplier)
              .Where(s => s.OrderDetail.Order.OrderDate < new DateTime(2021, 12, 12)).ToList();
            foreach (var i in product4)
            {
                Console.WriteLine($"{i.OrderId} {i.OrderDate} {i.OrderDetail.Quantity} {i.OrderDetail.UnitPrice}" +
                    $"{i.Supplier.FirstName}  {i.Supplier.LastName}");
            }


            var product5 = context.Order.Include(x => x.OrderDetail)
              .ThenInclude(x => x.Product).ThenInclude(x => x.Inventory)
              .Where(s => s.OrderDetail.Product.Inventory.Quantity > s.OrderDetail.Quantity);
            foreach (var i in product5)
            {
                Console.WriteLine($"{i.OrderId} {i.OrderDate} {i.OrderDetail.Quantity} {i.OrderDetail.UnitPrice}");
            }

            var product6 = context.Order.Include(x => x.OrderDetail)
             .ThenInclude(x => x.Product).ThenInclude(x => x.Inventory)
             .Where(s => s.OrderDetail.Product.Inventory.Quantity < s.OrderDetail.Quantity);
            foreach (var i in product6)
            {
                Console.WriteLine($"{i.OrderId} {i.OrderDate} {i.OrderDetail.Quantity} {i.OrderDetail.UnitPrice}");
            }
        }
    }
}
