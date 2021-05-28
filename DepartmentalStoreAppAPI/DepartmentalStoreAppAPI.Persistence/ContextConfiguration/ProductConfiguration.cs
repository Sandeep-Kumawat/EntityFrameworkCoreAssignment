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
    public class ProductConfiguration :IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(s => s.ProductId);
            builder.HasMany(s => s.ProductSuppliers).WithOne(s => s.Product);
            builder.Property(s => s.ProductName).HasMaxLength(30).IsRequired();
            builder.Property(s => s.ProductCode).HasMaxLength(30).IsRequired();
            builder.Property(s => s.CurrentQuantity).IsRequired();
            

        }
    }
}
