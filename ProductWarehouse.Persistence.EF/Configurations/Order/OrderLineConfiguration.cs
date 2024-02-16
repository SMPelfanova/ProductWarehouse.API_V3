using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.EF.Constants;

namespace ProductWarehouse.Persistence.EF.Configurations;

public class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
{
    public void Configure(EntityTypeBuilder<OrderLine> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Quantity)
            .IsRequired()
            .HasDefaultValue(1);

        builder.Property(p => p.Price)
            .HasColumnType(DatabaseConstants.DecimalColumnType)
            .IsRequired();

        builder.HasOne(b => b.Orders)
            .WithMany(p => p.OrderLines)
            .HasForeignKey(b => b.OrderId);

        builder.HasOne(b => b.Size)
            .WithMany(p => p.OrderLines)
            .HasForeignKey(b => b.SizeId);
    }
}