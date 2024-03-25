using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.PostgreSQL.Constants;

namespace ProductWarehouse.Persistence.PostgreSQL.Configurations;

public class UserConfiguration : EntityConfiguration<ProductWarehouse.Domain.Entities.User>
{
	public override void Configure(EntityTypeBuilder<ProductWarehouse.Domain.Entities.User> builder)
	{
		base.Configure(builder);

		builder.Property(p => p.FirstName)
			.IsRequired()
			.HasMaxLength(DatabaseConstants.Fifty);

		builder.Property(p => p.LastName)
			.IsRequired()
			.HasMaxLength(DatabaseConstants.Fifty);

		builder.Property(p => p.Email)
			.IsRequired()
			.HasMaxLength(DatabaseConstants.Hundred);

		builder.Property(p => p.Password).IsRequired();

		builder.Property(p => p.Phone)
			.IsRequired()
			.HasMaxLength(DatabaseConstants.Twenty);

		builder.Property(p => p.Address)
			.IsRequired()
			.HasMaxLength(DatabaseConstants.TwoHundredFiftyFive);

		builder.HasOne(b => b.Basket)
			.WithOne(p => p.User)
			.HasForeignKey<Baskets>(b => b.UserId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}