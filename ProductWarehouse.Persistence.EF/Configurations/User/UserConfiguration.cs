using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Persistence.EF.Configurations;

public class UserConfiguration : EntityConfiguration<User>
{
	public override void Configure(EntityTypeBuilder<User> builder)
	{
		base.Configure(builder);

		builder.Property(p => p.FirstName)
			.IsRequired()
			.HasMaxLength(50);

		builder.Property(p => p.LastName)
			.IsRequired()
			.HasMaxLength(50);

		builder.Property(p => p.Email)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(p => p.Password).IsRequired();

		builder.Property(p => p.Phone)
			.IsRequired()
			.HasMaxLength(20);

		builder.Property(p => p.Address)
			.IsRequired()
			.HasMaxLength(255);

		builder.HasOne(b => b.Basket)
			.WithOne(p => p.User)
			.HasForeignKey<Basket>(b => b.UserId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}