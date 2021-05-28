using DepartmentalStoreAppAPI.Application.RepositoryInterface;
using DepartmentalStoreAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStoreAppAPI.Persistence.Repositories
{
    public class StaffRepository : GeneralRepository<Staff>,IStaffRepository
    { 

        public StaffRepository(DepartmentalStoreContext context, ILogger<StaffRepository> logger) : base(context,logger)
        {
           
        }
        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempitng to save the changes in the context");

            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }
        public async Task<Staff[]> GetAllStaffsAsync(bool includeStaffRole = false)
        {
            _logger.LogInformation($"Getting all Staff Member");

            IQueryable<Staff> query = _context.Staff
                .Include(c => c.Address);

            if (includeStaffRole)
            {
                query = query
                  .Include(c => c.StaffRole);

            }
            query = query.OrderByDescending(c => c.StaffId);
            return await query.ToArrayAsync();
        }
        //public Staff[] GetAllStaffsSync()
        //{
        //    _logger.LogInformation($"Getting all Staff Member");

        //    IQueryable<Staff> query = _context.Staff;
        //    //    .Include(c => c.Address);

        //    //if (includeStaffRole)
        //    //{
        //    //    query = query
        //    //      .Include(c => c.StaffRole);

        //    //}
        //    //query = query.OrderByDescending(c => c.StaffId);
        //    return query.ToArray();
        //}
        
        public async Task<Staff> GetAStaffAsync(string name, bool includeStaffRole = false)
        {
            _logger.LogInformation($"Getting a Staff for {name}");

            IQueryable<Staff> query = _context.Staff
                .Include(c => c.Address);

            if (includeStaffRole)
            {
                query = query.Include(c => c.StaffRole);
                  
            }

            // Query It
            query = query.Where(c => c.FirstName == name);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Staff> GetAStaffAsyncByID(int id, bool includeStaffRole = false)
        {
            _logger.LogInformation($"Getting a Staff for {id}");

            IQueryable<Staff> query = _context.Staff.AsNoTracking()
                .Include(c => c.Address);

            if (includeStaffRole)
            {
                query = query.Include(c => c.StaffRole);

            }

            // Query It
            query = query.Where(c => c.StaffId == id);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Staff[]> GetAllStaffByRole(string rolename, bool includeRole = false)
        {
            _logger.LogInformation($"Getting all Staff");

            IQueryable<Staff> query = _context.Staff
                .Include(c => c.Address);

            if (includeRole)
            {
                query = query
                  .Include(c => c.StaffRole);
            }
            // Order It
            query = query.OrderByDescending(c => c.StaffId)
              .Where(c => c.StaffRole.RoleName == rolename);
            return await query.ToArrayAsync();
        }
        public async Task<StaffRole> GetStaffRoleAsync(int staffId)
        {
            _logger.LogInformation($"Getting StaffRole");

            var query = _context.StaffRole
              .Where(t => t.StaffRoleId == staffId);

            return await query.FirstOrDefaultAsync();
        }

        //public async Task<Staff> UpdateStaff(Staff staff)
        //{
        //    _context.Staff.Attach(staff);
           
        //}
    }
}
