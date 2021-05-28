using DepartmentalStoreAppAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStoreAppAPI.Application.RepositoryInterface
{
    public interface IStaffRepository : IGeneralRepository<Staff>
    {
        Task<bool> SaveChangesAsync();

        // Camps
        Task<Staff[]> GetAllStaffsAsync(bool includeStaffRole);
        //Staff[] GetAllStaffsSync();
        Task<Staff> GetAStaffAsync(string name, bool includeTalks = false);
        Task<Staff> GetAStaffAsyncByID(int id, bool includeStaffRole = false);
        Task<Staff[]> GetAllStaffByRole(string rolename, bool includeRole = false);
        Task<StaffRole> GetStaffRoleAsync(int staffId);
        //Task<Staff> UpdateStaff(Staff staff);
    }
}
