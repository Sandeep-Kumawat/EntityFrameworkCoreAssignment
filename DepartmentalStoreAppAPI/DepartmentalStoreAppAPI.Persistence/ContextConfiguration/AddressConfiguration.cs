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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(s => s.AddressId);
            builder.Property(s => s.AddressLine1).HasMaxLength(128).IsRequired();
            builder.Property(s => s.AddressLine2).HasMaxLength(64).IsRequired();
            builder.Property(s => s.City).HasMaxLength(64).IsRequired();
            builder.Property(s => s.PostalCode).HasMaxLength(6).IsRequired();
            builder.Property(s => s.State).HasMaxLength(64).IsRequired();
        }
        
    }
}
