using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.EF.Constants;

namespace ProductWarehouse.Persistence.EF.Configurations;
public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable(nameof(TableNames.Payments));

        builder.HasKey(t => t.Id);

        builder.Property(p => p.Method).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Status).IsRequired().HasMaxLength(50);

        builder.Property(p => p.PaymentDate).IsRequired();
        builder.Property(t => t.PaymentDate)
            .IsRequired()
            .HasColumnType("Date")
            .HasDefaultValueSql("GetDate()");

        builder.HasOne(b => b.Order)
            .WithOne(p => p.Payment)
            .HasForeignKey<Order>(b => b.PaymentId)
            .IsRequired(false);
    }
}
