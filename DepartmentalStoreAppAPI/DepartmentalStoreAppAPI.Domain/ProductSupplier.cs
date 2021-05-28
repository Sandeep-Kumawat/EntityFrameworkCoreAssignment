using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStoreAppAPI.Domain
{
    public class ProductSupplier
    {
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public Product Product { get; set; }
        public Supplier Supplier { get; set; }
    }
}
