using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Persistence.EF.Configurations;
public class PaymentConfiguration : EntityConfiguration<Payment>
{
	public override void Configure(EntityTypeBuilder<Payment> builder)
	{
		base.Configure(builder);

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
