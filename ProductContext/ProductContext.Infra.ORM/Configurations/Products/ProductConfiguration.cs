using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductContext.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductContext.Infra.ORM.Configurations.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Tb_Product");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().HasColumnName("IdProduct");
            builder.Property(x => x.Description).IsRequired().HasColumnName("Description");
            builder.Property(x => x.Situation).IsRequired().HasColumnName("Situation");
            builder.Property(x => x.ManufacturingDate).HasColumnName("ManufacturingDate");
            builder.Property(x => x.DueDate).HasColumnName("DueDate");
            builder.Property(x => x.IdProvider).HasColumnName("IdProvider");
            builder.Property(x => x.DescriptionProvider).HasColumnName("DescriptionProvider");
            builder.Property(x => x.CNPJProvider).HasColumnName("CNPJProvider");

        }
    }
}
