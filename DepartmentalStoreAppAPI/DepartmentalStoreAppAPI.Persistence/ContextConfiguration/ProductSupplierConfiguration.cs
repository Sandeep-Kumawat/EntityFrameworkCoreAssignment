using DepartmentalStoreAppAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStoreAppAPI.Persistence.ContextConfiguration
{
    public class ProductSupplierConfiguration : IEntityTypeConfiguration<ProductSupplier>
    {
        public void Configure(EntityTypeBuilder<ProductSupplier> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.SupplierId });
            builder.HasOne(s => s.Supplier).WithMany(s => s.ProductSuppliers).HasForeignKey(s=>s.SupplierId);
            builder.HasOne(s => s.Product).WithMany(s => s.ProductSuppliers).HasForeignKey(s => s.ProductId);
        }
    }
}
