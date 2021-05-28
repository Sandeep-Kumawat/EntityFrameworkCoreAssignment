using DepartmentalStoreAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStoreAppAPI.Persistence.ContextConfiguration
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(s => s.StaffId);
            builder.HasOne(s => s.Address).WithMany().HasForeignKey(s => s.AddressId);
            builder.HasOne(s => s.StaffRole).WithMany(s => s.Staffs).HasForeignKey(s => s.StaffRoleId);
            builder.Property(s => s.FirstName).HasMaxLength(30).IsRequired();
            builder.Property(s => s.LastName).HasMaxLength(30).IsRequired();
            builder.Property(s => s.BirthDate).IsRequired();
            builder.Property(s => s.Phone).HasMaxLength(10).IsRequired();
            builder.Property(s => s.Salary).IsRequired();
        }
    }
}
