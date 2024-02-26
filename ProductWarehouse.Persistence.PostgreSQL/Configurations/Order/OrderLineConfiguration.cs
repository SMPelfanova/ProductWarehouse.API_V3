using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.PostgreSQL.Constants;

namespace ProductWarehouse.Persistence.PostgreSQL.Configurations;

public class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
{
    public void Configure(EntityTypeBuilder<OrderLine> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Quantity)
            .IsRequired()
            .HasDefaultValue(DatabaseConstants.One);

        builder.Property(p => p.Price)
            .HasColumnType(DatabaseConstants.DecimalColumnTypeNpgsql)
            .IsRequired();

        builder.HasOne(b => b.Orders)
            .WithMany(p => p.OrderLines)
            .HasForeignKey(b => b.OrderId);

        builder.HasOne(b => b.Size)
            .WithMany(p => p.OrderLines)
            .HasForeignKey(b => b.SizeId);
    }
}