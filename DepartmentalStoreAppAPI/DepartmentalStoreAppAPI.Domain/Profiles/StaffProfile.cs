using AutoMapper;
using DepartmentalStoreAppAPI.Application.Models;
using DepartmentalStoreAppAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStoreAppAPI.Domain
{
    public class StaffProfile :Profile
    {
        public StaffProfile()
        {
            this.CreateMap<Staff, StaffModel>()
               
                .ReverseMap();
             //.ForMember(c => c.StaffRole, opt => opt.MapFrom(s => s.StaffRole.RoleName))
            this.CreateMap<StaffRole, StaffRoleModel>().ReverseMap();
        }
    }
}
