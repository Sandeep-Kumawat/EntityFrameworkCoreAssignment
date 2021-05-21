using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStoreApp.Domain
{
    public class Product
    {
        public Product()
        {
            ProductCategories = new List<ProductCategory>();
            Suppliers = new List<Supplier>();
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int CurrentQuantity { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public ProductDetail ProductDetail { get; set; }
        public Inventory Inventory { get; set; }

    }
}
