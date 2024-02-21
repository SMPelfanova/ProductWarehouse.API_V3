using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.EF.Constants;

namespace ProductWarehouse.Persistence.EF.Configurations;

public class RoleConfiguration : EntityConfiguration<Role>
{
	public override void Configure(EntityTypeBuilder<Role> builder)
	{
		base.Configure(builder);

		builder.Property(p => p.Name)
			.IsRequired()
			.HasMaxLength(DatabaseConstants.Fifty);
	}
}