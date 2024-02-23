using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.EF.Constants;

namespace ProductWarehouse.Persistence.EF.Configurations;

public class PaymentConfiguration : EntityConfiguration<Payment>
{
	public override void Configure(EntityTypeBuilder<Payment> builder)
	{
		base.Configure(builder);

		builder.Property(p => p.Method)
			.IsRequired()
			.HasMaxLength(DatabaseConstants.Fifty);

		builder.Property(p => p.Status)
			.IsRequired()
			.HasMaxLength(DatabaseConstants.Fifty);

		builder.Property(t => t.PaymentDate)
			.IsRequired()
			.HasColumnType(DatabaseConstants.DateColumnTypeNpgsql)
			.HasDefaultValueSql(DatabaseConstants.DateDefaultValueNpgsql);

		builder.HasOne(b => b.Order)
			.WithOne(p => p.Payment)
			.HasForeignKey<Order>(b => b.PaymentId)
			.IsRequired(false);
	}
}