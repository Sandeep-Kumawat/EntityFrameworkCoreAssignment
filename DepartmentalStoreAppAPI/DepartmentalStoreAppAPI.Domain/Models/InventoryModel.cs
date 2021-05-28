using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStoreAppAPI.Domain.Models
{
    public class InventoryModel
    {
        public int InventoryId { get; set; }
        public int Quantity { get; set; }
        public bool InStocks { get; set; }
        public int ProductId { get; set; }
    }
}
