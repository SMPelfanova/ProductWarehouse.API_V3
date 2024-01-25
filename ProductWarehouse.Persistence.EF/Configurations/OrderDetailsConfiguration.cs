using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.EF.Constants;

namespace ProductWarehouse.Persistence.EF.Configurations;
public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
{
    public void Configure(EntityTypeBuilder<OrderDetails> builder)
    {
        builder.ToTable(nameof(TableNames.OrderDetails));

        builder.HasKey(pg => new { pg.OrderId, pg.ProductId });

        builder.Property(p => p.Quantity).IsRequired();
        builder.Property(p => p.Price)
            .HasColumnType("decimal(18, 2)")
            .IsRequired();

        builder.HasOne(b => b.Orders)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(b => b.OrderId);

        builder.HasOne(b => b.Product)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(b => b.ProductId);

        builder.HasOne(b => b.Size)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(b => b.SizeId);

    }
}
