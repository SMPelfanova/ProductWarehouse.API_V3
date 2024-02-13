using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.EF.Constants;

namespace ProductWarehouse.Persistence.EF.Configurations;
public class OrderStatusConfiguration : EntityConfiguration<OrderStatus>
{
	public override void Configure(EntityTypeBuilder<OrderStatus> builder)
	{
		base.Configure(builder);

		builder.ToTable(nameof(TableNames.OrderStatus));

		builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
	}
}
