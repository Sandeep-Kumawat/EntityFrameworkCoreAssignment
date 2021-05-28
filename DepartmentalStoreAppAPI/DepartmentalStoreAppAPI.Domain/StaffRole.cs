using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStoreAppAPI.Domain
{
    public class StaffRole
    {
        public StaffRole()
        {
            Staffs = new List<Staff>();
        }
        public int StaffRoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public List<Staff> Staffs { get; set; }
    }
}
