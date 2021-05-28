using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStoreAppAPI.Domain
{
    public class Supplier
    {
        public Supplier()
        {
            ProductSuppliers = new List<ProductSupplier>();
        }
        public int SupplierId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<ProductSupplier> ProductSuppliers { get; set; }
        public Address Address { get; set; }
    }
}
