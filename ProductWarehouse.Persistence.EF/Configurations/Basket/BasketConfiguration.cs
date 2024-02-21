using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Persistence.EF.Configurations;

public class BasketConfiguration : EntityConfiguration<Baskets>
{
	public override void Configure(EntityTypeBuilder<Baskets> builder)
	{
		base.Configure(builder);

		builder.HasOne(b => b.User)
			.WithOne(b => b.Basket)
			.HasForeignKey<Baskets>(b => b.UserId);
	}
}