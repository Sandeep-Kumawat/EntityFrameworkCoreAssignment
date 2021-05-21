using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStoreApp.Domain
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StaffRoleId { get; set; }
        public DateTime BirthDate { get; set; }
        public int AddressId { get; set; }
        public string Phone { get; set; }
        public double Salary { get; set; }
        public StaffRole StaffRole { get; set; }
        public Address Address { get; set; }
    }
}
