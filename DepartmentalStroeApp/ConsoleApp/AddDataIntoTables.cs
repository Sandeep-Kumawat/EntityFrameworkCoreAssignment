using DepartmentalStoreApp.Data;
using DepartmentalStoreApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class AddDataIntoTables
    {
        public static DepartmentalStoreContext context = new DepartmentalStoreContext();
        public static void AddDataIntoAddress()
        {
            var address = new Address
            {
                AddressLine1= "Khetan Colony",
                AddressLine2= "A-1",
                PostalCode = "332025",
                City = "Sikar",
                State = "Raj"

            };
            var address1 = new Address
            {
                AddressLine1 = "Adani Colony",
                AddressLine2 = "B-1",
                PostalCode = "312121",
                City = "Jaipur",
                State = "Raj"

            };
            var address2 = new Address
            {
                AddressLine1 = "Khetan Colony",
                AddressLine2 = "C-1",
                PostalCode = "332020",
                City = "Alwar",
                State = "Raj"

            };
            var address3 = new Address
            {
                AddressLine1 = "Ambani Colony",
                AddressLine2 = "A-1",
                PostalCode = "332025",
                City = "Sikar",
                State = "Raj"

            };
            var address4 = new Address
            {
                AddressLine1 = "Shanti Vihar",
                AddressLine2 = "RN-19",
                PostalCode = "111421",
                City = "Noida",
                State = "UP"

            };
            var address5 = new Address
            {
                AddressLine1 = "Gandhi",
                AddressLine2 = "RN-9",
                PostalCode = "203947",
                City = "Delhi",
                State = "Delhi"

            };
            context.Address.AddRange(address,address1,address2,address3,address4,address5);
            context.SaveChanges();
        }
        public static void AddDataIntoStaffRole()
        {
            var staffRole = new StaffRole
            {
                RoleName = "Manager",
                Description = "manage store"
            };
            var staffRole1 = new StaffRole
            {
                RoleName = "Cashier",
                Description = "Cash Counter"
            };
            var staffRole2 = new StaffRole
            {
                RoleName = "CSR",
                Description = "Representative"
            };
            var staffRole3 = new StaffRole
            {
                RoleName = "ICS",
                Description = "Inventory Mange"
            };
            var staffRole4 = new StaffRole
            {
                RoleName = "Cashier",
                Description = "Cash Counter"
            };
            context.StaffRole.AddRange(staffRole, staffRole1, staffRole2, staffRole3, staffRole4);
            context.SaveChanges();
        }
        public static void AddDataIntoStaff()
        {
            var staff = new Staff
            {
                FirstName= "Sandeep",
                LastName="Kumawat",
                StaffRoleId=1,
                BirthDate = new DateTime(1996,07,07),
                Phone = "9887729448",
                AddressId=1,
                Salary= 30000
            };
            var staff1 = new Staff
            {
                FirstName = "Pradeep",
                LastName = "Kumawat",
                StaffRoleId = 2,
                BirthDate = new DateTime(1998,09,15),
                Phone = "1232344456",
                AddressId = 2,
                Salary = 20000
            };
            var staff2 = new Staff
            {
                FirstName = "Ritik",
                LastName = "Sharma",
                StaffRoleId = 3,
                BirthDate = new DateTime(1999, 10, 07),
                Phone = "1234543210",
                AddressId = 3,
                Salary = 20000
            };
            var staff3 = new Staff
            {
                FirstName = "Palak",
                LastName = "Madan",
                StaffRoleId = 4,
                BirthDate = new DateTime(1995, 03,24),
                Phone = "9876543210",
                AddressId = 4,
                Salary = 15000
            };
            var staff4 = new Staff
            {
                FirstName = "Divya",
                LastName = "Talvar",
                StaffRoleId = 5,
                BirthDate = new DateTime(1996, 07, 07),
                Phone = "2345467808",
                AddressId = 5,
                Salary = 18000
            };
            
            context.Staff.AddRange(staff,staff1, staff2, staff3, staff4);
            context.SaveChanges();
        }
        public static void AddDataIntoCategory()
        {
            var category = new Category
            {
                CategoryName = "Shopping Goods",
                CategoryCode = "Shop",
                Description = "Shopping Goods"
            };
            var category1 = new Category
            {
                CategoryName = "Convenience Goods",
                CategoryCode = "Conv",
                Description = "Convenience Goods"
            };
            var category2 = new Category
            {
                CategoryName = "Specialty Goods",
                CategoryCode = "Spec",
                Description = "Specialty Goods"
            };
            var category3 = new Category
            {
                CategoryName = "Unsought Goods",
                CategoryCode = "Unso",
                Description = "Unsought Goods"
            };
            var category4 = new Category
            {
                CategoryName = "Luxury Goods",
                CategoryCode = "Luxu",
                Description = "Luxury Goods"
            };
            var category5 = new Category
            {
                CategoryName = "Technical Goods",
                CategoryCode = "Tech",
                Description = "Technical Goods"
            };
            context.Category.AddRange(category, category1, category2, category3, category4, category5);
            context.SaveChanges();
        }
        public static void AddDataIntoSupplier()
        {
            var supplier = new Supplier
            {
                FirstName = "Rohan",
                LastName = "Gupta",
                AddressId = 1,
                PhoneNumber = "122345565",
                Email= "rohan@gmail.com"
            };
            var supplier1 = new Supplier
            {
                FirstName = "Vikas",
                LastName = "Kumar",
                AddressId = 2,
                PhoneNumber = "23243456",
                Email = "vikas@gmail.com"
            };
            var supplier2 = new Supplier
            {
                FirstName = "Gopal",
                LastName = "Sharma",
                AddressId = 3,
                PhoneNumber = "9999877644",
                Email = "gopal@gmail.com"
            };
            var supplier3 = new Supplier
            {
                FirstName = "Gaurav",
                LastName = "Pandey",
                AddressId = 4,
                PhoneNumber = "122345565",
                Email = "gaurav@gmail.com"

            };
            var supplier4 = new Supplier
            {
                FirstName = "Abhi",
                LastName = "Khurana",
                AddressId = 5,
                PhoneNumber = "9876544334",
                Email = "abhi@gmail.com"

            };
            context.Supplier.AddRange(supplier, supplier1, supplier2, supplier3, supplier4);
            context.SaveChanges();
        }
        public static void AddDataIntoProduct()
        {
            var product = new Product
            {
              
                ProductName = "Laptop",
                ProductCode= "lap",
                CurrentQuantity=10
                
            };
            var product1 = new Product
            {
                ProductName = "Mobile",
                ProductCode = "Mob",
                CurrentQuantity = 20
            };
            var product2 = new Product
            {
                ProductName = "Pen",
                ProductCode = "Pen",
                CurrentQuantity = 30
            };
            var product3 = new Product
            {
                ProductName = "Bottle",
                ProductCode = "Bot",
                CurrentQuantity = 50
            };
            var product4 = new Product
            {
                ProductName = "Watch",
                ProductCode = "Wat",
                CurrentQuantity = 5
            };
            var product5 = new Product
            {
                ProductName = "Shoes",
                ProductCode = "Sho",
                CurrentQuantity = 25
            };
            var product6 = new Product
            {
                ProductName = "Ball",
                ProductCode = "Ball",
                CurrentQuantity = 50
            };
            context.Product.AddRange(product, product1, product2, product3, product4, product5, product6);
            context.SaveChanges();
        }
        public static void AddDataIntoProductCategory()
        {
            var pc = new ProductCategory
            {
                ProductId=1,
                CategoryId=1
            };
            var pc1 = new ProductCategory
            {
                ProductId = 1,
                CategoryId = 2
            };
            var pc2 = new ProductCategory
            {
                ProductId = 2,
                CategoryId = 4
            };
            var pc3 = new ProductCategory
            {
                ProductId = 2,
                CategoryId = 5
            };
            var pc4 = new ProductCategory
            {
                ProductId = 3,
                CategoryId = 4
            };
            var pc5 = new ProductCategory
            {
                ProductId = 4,
                CategoryId = 1
            };
            var pc6 = new ProductCategory
            {
                ProductId = 5,
                CategoryId = 3
            };
            var pc7 = new ProductCategory
            {
                ProductId = 5,
                CategoryId = 5
            };
            context.ProductCategory.AddRange(pc, pc1, pc2, pc3, pc4, pc5, pc6, pc7);
            context.SaveChanges();
        }
        public static void AddDataIntoInventory()
        {
            var inven = new Inventory
            {
                ProductId=1,
                Quantity=10,
                InStocks=true
            };
            var inven1 = new Inventory
            {
                ProductId = 2,
                Quantity = 20,
                InStocks = true
            };
            var inven2 = new Inventory
            {
                ProductId = 3,
                Quantity = 100,
                InStocks = true
            };
            var inven3 = new Inventory
            {
                ProductId = 4,
                Quantity = 0,
                InStocks = false
            };
            var inven4 = new Inventory
            {
                ProductId = 5,
                Quantity = 3,
                InStocks = true
            };
            var inven5 = new Inventory
            {
                ProductId = 6,
                Quantity = 0,
                InStocks = false
            };
            var inven6 = new Inventory
            {
                ProductId = 7,
                Quantity = 10,
                InStocks = true
            };
            context.Inventory.AddRange(inven, inven1, inven2, inven3, inven4, inven5, inven6);
            context.SaveChanges();
        }
        public static void AddDataIntoProductDetail()
        {
            var pd = new ProductDetail
            {
                ProductId = 1,
                CostPrice = 15000,
                SellingPrice = 18000,
                DateOfPrice = new DateTime(2021, 05, 15)
            };
            var pd1 = new ProductDetail
            {
                ProductId = 2,
                CostPrice = 8000,
                SellingPrice = 10000,
                DateOfPrice = new DateTime(2020,05,12)
            };
            var pd3 = new ProductDetail
            {
                ProductId = 3,
                CostPrice = 20,
                SellingPrice = 30,
                DateOfPrice = new DateTime(2020,01,01)
            };
            var pd4 = new ProductDetail
            {
                ProductId = 4,
                CostPrice = 100,
                SellingPrice = 130,
                DateOfPrice = new DateTime(2019,12,12)
            };
            var pd5 = new ProductDetail
            {
                ProductId = 5,
                CostPrice = 2500,
                SellingPrice = 3000,
                DateOfPrice = new DateTime(2020,07,07)
            };
            var pd6 = new ProductDetail
            {
                ProductId = 6,
                CostPrice = 3000,
                SellingPrice = 3500,
                DateOfPrice = new DateTime(2021,04,04)
            };
            var pd7 = new ProductDetail
            {
                ProductId = 7,
                CostPrice = 50,
                SellingPrice = 70,
                DateOfPrice = new DateTime(2020,10,10)
            };
            context.ProductDetail.AddRange(pd, pd1,pd3, pd4, pd5, pd6, pd7);
            context.SaveChanges();
        }
        public static void AddDataIntoOrder()
        {
            var od = new Order
            {
                 SupplierId = 1,
                 OrderDate = new DateTime(2021,05,05)
            };
            var od1 = new Order
            {
                SupplierId = 2,
                OrderDate = new DateTime(2020,05,10)
            };
            var od2 = new Order
            {
                SupplierId = 3,
                OrderDate = new DateTime(2021,01,01)
            };
            var od3 = new Order
            {
                SupplierId = 4,
                OrderDate = new DateTime(2020,10,10)
            };
            var od4 = new Order
            {
                SupplierId = 5,
                OrderDate = new DateTime(2020,12,12)
            };
            var od5 = new Order
            {
                SupplierId = 2,
                OrderDate = new DateTime(2021,05,15)
            };
            context.Order.AddRange(od, od1, od2, od3, od4, od5);
            context.SaveChanges();
        }
        public static void AddDataIntoOrderDetail()
        {
            var od = new OrderDetail
            {
                OrderId =1,
                ProductId =1,
                UnitPrice=18000,
                Quantity =2
            };
            var od1 = new OrderDetail
            {
                OrderId=2,
                ProductId = 2,
                UnitPrice = 8000,
                Quantity = 5
            };
            var od2 = new OrderDetail
            {
                OrderId =3,
                ProductId = 3,
                UnitPrice = 50,
                Quantity = 3
            };
            var od3 = new OrderDetail
            {
                OrderId=4,
                ProductId = 4,
                UnitPrice = 100,
                Quantity = 10
            };
            var od4 = new OrderDetail
            {
                OrderId=5,
                ProductId = 5,
                UnitPrice = 2500,
                Quantity = 3
            };
            var od5 = new OrderDetail
            {
                OrderId=6,
                ProductId = 1,
                UnitPrice = 21000,
                Quantity = 5
            };
            
            context.OrderDetail.AddRange( od1, od2, od3, od4,od5);
            context.SaveChanges();
        }
    }
}
