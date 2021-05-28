using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStoreAppAPI.Domain
{
    public class Product
    {
        public Product()
        {
            ProductCategories = new List<ProductCategory>();
           
            ProductSuppliers = new List<ProductSupplier>();
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int CurrentQuantity { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        
        public ProductDetail ProductDetail { get; set; }
        public Inventory Inventory { get; set; }
        public List<ProductSupplier> ProductSuppliers { get; set; }
    }
}
