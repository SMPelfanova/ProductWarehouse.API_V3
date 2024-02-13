using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Persistence.EF.Configurations;
public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
{
	public virtual void Configure(EntityTypeBuilder<T> builder)
	{
		builder.ToTable(typeof(T).Name + "s");
		builder.HasKey(e => e.Id);
		builder.Property(e => e.CreatedAt).IsRequired().HasColumnType("Date").HasDefaultValueSql("GetDate()");
	}
}
