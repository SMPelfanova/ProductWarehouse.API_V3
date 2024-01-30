using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.EF.Constants;

namespace ProductWarehouse.Persistence.EF.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable(nameof(TableNames.Orders));

        builder.HasKey(p => p.Id);

        builder.Property(p => p.TotalAmount)
            .HasColumnType("decimal(18, 2)")
            .IsRequired();

        builder.Property(p => p.OrderDate).IsRequired();

        builder.Property(t => t.OrderDate)
            .IsRequired()
            .HasColumnType("Date")
            .HasDefaultValueSql("GetDate()");

        builder.HasOne(b => b.Status)
            .WithMany(p => p.Orders)
            .HasForeignKey(b => b.StatusId);

        builder.HasOne(b => b.User)
            .WithMany(p => p.Orders)
            .HasForeignKey(b => b.Userid).IsRequired(false);

        builder.HasOne(b => b.Payment)
            .WithMany(p => p.Orders)
            .HasForeignKey(b => b.PaymentId).IsRequired(false);
    }
}
