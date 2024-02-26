using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.PostgreSQL.Constants;

namespace ProductWarehouse.Persistence.PostgreSQL.Configurations;

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