using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.EF.Constants;

namespace ProductWarehouse.Persistence.EF.Configurations;
public class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
{
    public void Configure(EntityTypeBuilder<OrderLine> builder)
    {
        builder.ToTable(nameof(TableNames.OrderLines));

        builder.HasKey(pg => new { pg.OrderId, pg.ProductId });

        builder.Property(p => p.Quantity)
            .IsRequired()
            .HasDefaultValue(1);

        builder.Property(p => p.Price)
            .HasColumnType("decimal(18, 2)")
            .IsRequired();

        builder.HasOne(b => b.Orders)
            .WithMany(p => p.OrderLines)
            .HasForeignKey(b => b.OrderId);

        builder.HasOne(b => b.Product)
            .WithMany(p => p.OrderLines)
            .HasForeignKey(b => b.ProductId);

        builder.HasOne(b => b.Size)
            .WithMany(p => p.OrderLines)
            .HasForeignKey(b => b.SizeId);

    }
}
