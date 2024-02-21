using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.EF.Constants;

namespace ProductWarehouse.Persistence.EF.Configurations;

public class GroupConfiguration : EntityConfiguration<Group>
{
	public override void Configure(EntityTypeBuilder<Group> builder)
	{
		base.Configure(builder);

		builder.Property(p => p.Name)
			.IsRequired()
			.HasMaxLength(DatabaseConstants.Hundred);
	}
}