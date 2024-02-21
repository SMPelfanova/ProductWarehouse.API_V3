using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.EF.Constants;

namespace ProductWarehouse.Persistence.EF.Configurations;

public class BrandConfiguration : EntityConfiguration<Brand>
{
	public override void Configure(EntityTypeBuilder<Brand> builder)
	{
		base.Configure(builder);

		builder.Property(p => p.Name)
			.IsRequired()
			.HasMaxLength(DatabaseConstants.Hundred);
	}
}