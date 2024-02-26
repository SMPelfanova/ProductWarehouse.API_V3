﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.PostgreSQL.Constants;

namespace ProductWarehouse.Persistence.PostgreSQL.Configurations;

public class ProductSizesConfiguration : IEntityTypeConfiguration<ProductSize>
{
	public void Configure(EntityTypeBuilder<ProductSize> builder)
	{
		builder.HasKey(pg => new { pg.ProductId, pg.SizeId });

		builder.Property(p => p.QuantityInStock)
			.IsRequired()
			.HasDefaultValue(DatabaseConstants.One);

		builder.HasOne(ps => ps.Product)
			.WithMany(ps => ps.ProductSizes)
			.HasForeignKey(ps => ps.ProductId);

		builder.HasOne(ps => ps.Size)
			.WithMany(ps => ps.ProductSizes)
			.HasForeignKey(ps => ps.SizeId);
	}
}