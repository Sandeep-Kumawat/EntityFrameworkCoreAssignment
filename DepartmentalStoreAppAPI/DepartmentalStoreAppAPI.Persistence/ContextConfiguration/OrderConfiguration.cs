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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(s => s.OrderId);
            builder.HasOne(s => s.Supplier).WithMany().HasForeignKey(s => s.SupplierId);
            builder.Property(s => s.OrderDate).IsRequired();
        }
    }
}
