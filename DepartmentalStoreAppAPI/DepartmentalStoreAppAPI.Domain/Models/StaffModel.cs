using DepartmentalStoreAppAPI.Domain;
using DepartmentalStoreAppAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStoreAppAPI.Application.Models
{
    public class StaffModel
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public double Salary { get; set; }
        public Address Address { get; set; }
        public StaffRoleModel StaffRole { get; set; }
    }
}
