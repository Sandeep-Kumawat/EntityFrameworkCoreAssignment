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
    public class StaffRoleConfiguration : IEntityTypeConfiguration<StaffRole>
    {
        public void Configure(EntityTypeBuilder<StaffRole> builder)
        {
            builder.HasKey(s => s.StaffRoleId);
            builder.HasMany(s => s.Staffs).WithOne(s => s.StaffRole);
            builder.Property(s => s.RoleName).HasMaxLength(64).IsRequired();
            builder.Property(s => s.Description).HasMaxLength(128).IsRequired();
        }
    }
}
