using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStoreApp.Domain
{
    public class Supplier
    {
        public Supplier()
        {
            Products = new List<Product>();
        }
        public int SupplierId{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Product> Products { get; set; }
        public Address Address { get; set; }
    }
}
