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
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(s => s.SupplierId);
            builder.HasOne(s => s.Address).WithMany().HasForeignKey(s => s.AddressId);
            builder.Property(s => s.FirstName).HasMaxLength(30).IsRequired();
            builder.Property(s => s.LastName).HasMaxLength(30).IsRequired();
            builder.Property(s => s.PhoneNumber).HasMaxLength(10).IsRequired();
            builder.Property(s => s.Email).HasMaxLength(30).IsRequired();
            builder.HasMany(s => s.ProductSuppliers).WithOne(s => s.Supplier);
        }
    }
}
