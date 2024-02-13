using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Persistence.EF.Configurations;

public class SizeConfiguration : EntityConfiguration<Size>
{
	public override void Configure(EntityTypeBuilder<Size> builder)
	{
		base.Configure(builder);
		builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
	}
}