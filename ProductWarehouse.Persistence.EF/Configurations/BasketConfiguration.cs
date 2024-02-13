using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Persistence.EF.Configurations;
public class BasketConfiguration : EntityConfiguration<Basket>
{
	public override void Configure(EntityTypeBuilder<Basket> builder)
	{
		base.Configure(builder);

		builder.HasOne(b => b.User)
			.WithOne(b => b.Basket)
			.HasForeignKey<Basket>(b => b.UserId);
	}
}
