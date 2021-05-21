using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStoreApp.Domain
{
    public class Order
    {
        public int OrderId { get; set; }
        public int SupplierId { get; set; }
        public DateTime OrderDate { get; set; }
        public Supplier Supplier { get; set; }
        public OrderDetail OrderDetail { get; set; }
    }
}
