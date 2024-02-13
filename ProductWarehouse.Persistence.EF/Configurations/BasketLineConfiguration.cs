using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Persistence.EF.Configurations;

public class BasketLineConfiguration : EntityConfiguration<BasketLine>
{
	public override void Configure(EntityTypeBuilder<BasketLine> builder)
	{
		base.Configure(builder);

		builder.Property(p => p.Quantity)
			.IsRequired()
			.HasDefaultValue(1);

		builder.Property(p => p.Price)
	   .HasColumnType("decimal(18, 2)")
	   .IsRequired();

		builder.HasOne(bl => bl.Basket)
			.WithMany(bl => bl.BasketLines)
			.HasForeignKey(bl => bl.BasketId);

		builder.HasOne(bl => bl.Product)
			.WithMany(bl => bl.BasketLines)
			.HasForeignKey(bl => bl.ProductId);

		builder.HasOne(bl => bl.Size)
			 .WithMany(bl => bl.BasketLines)
			 .HasForeignKey(bl => bl.SizeId);
	}
}