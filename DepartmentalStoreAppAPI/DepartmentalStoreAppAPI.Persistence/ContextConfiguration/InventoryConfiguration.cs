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
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(s => s.InventoryId);
            builder.HasOne(s => s.Product).WithOne(s => s.Inventory)
                .HasForeignKey<Inventory>(s => s.ProductId);
            builder.Property(s => s.Quantity).IsRequired();
            builder.Property(s => s.InStocks).IsRequired();
        }
    }
}
