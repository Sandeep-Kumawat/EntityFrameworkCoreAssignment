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
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(s => s.OrderId);
            builder.HasOne(s => s.Order).WithOne(s => s.OrderDetail)
                .HasForeignKey<OrderDetail>(s => s.OrderId);
            builder.HasOne(s => s.Product).WithMany()
                .HasForeignKey(s => s.ProductId);
            builder.Property(s => s.Quantity).IsRequired();
            builder.Property(s => s.UnitPrice).IsRequired();
        }
    }
}
