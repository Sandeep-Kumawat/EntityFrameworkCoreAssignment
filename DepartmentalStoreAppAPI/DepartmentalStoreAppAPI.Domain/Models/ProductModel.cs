using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStoreAppAPI.Domain.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int CurrentQuantity { get; set; }
        public ProductDetailModel ProductDetail { get; set; }
        public InventoryModel Inventory { get; set; }
    }
}
