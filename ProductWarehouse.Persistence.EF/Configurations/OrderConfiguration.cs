using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Persistence.EF.Configurations;

public class OrderConfiguration : EntityConfiguration<Order>
{
	public override void Configure(EntityTypeBuilder<Order> builder)
	{
		base.Configure(builder);

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
			.HasForeignKey(b => b.UserId).IsRequired(false);

		builder.HasOne(o => o.Payment)
			.WithOne(p => p.Order)
			.HasForeignKey<Order>(o => o.PaymentId);
	}
}