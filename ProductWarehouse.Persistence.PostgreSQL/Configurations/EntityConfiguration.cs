using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.PostgreSQL.Constants;

namespace ProductWarehouse.Persistence.PostgreSQL.Configurations;

public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
{
	public virtual void Configure(EntityTypeBuilder<T> builder)
	{
		builder.HasKey(e => e.Id);

		builder.Property(e => e.Id)
				.IsRequired()
				.HasDefaultValueSql("gen_random_uuid()");

		builder.Property(e => e.CreatedAt)
			.IsRequired()
			.HasColumnType(DatabaseConstants.DateColumnTypeNpgsql)
			.HasDefaultValueSql(DatabaseConstants.DateDefaultValueNpgsql);
	}
}