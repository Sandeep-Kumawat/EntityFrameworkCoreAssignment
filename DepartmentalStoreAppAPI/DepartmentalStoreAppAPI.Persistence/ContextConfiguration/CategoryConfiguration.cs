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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(s => s.CategoryId);
            builder.Property(s => s.CategoryName).HasMaxLength(64).IsRequired();
            builder.Property(s => s.CategoryCode).HasMaxLength(64).IsRequired();
            builder.Property(s => s.Description).HasMaxLength(128).IsRequired();
        }
    }
}
