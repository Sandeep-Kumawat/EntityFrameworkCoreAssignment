using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStoreApp.Domain
{
    public class ProductDetail
    {
        public int ProductId { get; set; }
        public decimal CostPrice  { get; set; }
        public decimal SellingPrice { get; set; }
        public DateTime DateOfPrice { get; set; }
        public Product Product { get; set; }

    }
}
