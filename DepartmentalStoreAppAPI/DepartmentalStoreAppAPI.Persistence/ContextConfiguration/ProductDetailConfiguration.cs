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
    public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.HasKey(s => s.ProductId);
            builder.HasOne(s => s.Product).WithOne(s => s.ProductDetail)
                .HasForeignKey<ProductDetail>(s => s.ProductId);
            builder.Property(s => s.CostPrice).IsRequired();
            builder.Property(s => s.SellingPrice).IsRequired();
            builder.Property(s => s.DateOfPrice).IsRequired();
        }
    }
}
