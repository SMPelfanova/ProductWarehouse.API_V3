using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.EF.Constants;

namespace ProductWarehouse.Persistence.EF.Configurations;
public class ProductSizesConfiguration : IEntityTypeConfiguration<ProductSize>
{
    public void Configure(EntityTypeBuilder<ProductSize> builder)
    {
        builder.ToTable(nameof(TableNames.ProductSizes));

        builder.HasKey(pg => new { pg.ProductId, pg.SizeId });

        builder.Property(p => p.QuantityInStock)
            .IsRequired()
            .HasDefaultValue(1);

        builder.HasOne(ps => ps.Product)
            .WithMany(ps => ps.ProductSizes)
            .HasForeignKey(ps => ps.ProductId);

        builder.HasOne(ps => ps.Size)
            .WithMany(ps => ps.ProductSizes)
            .HasForeignKey(ps => ps.SizeId);
    }
}
