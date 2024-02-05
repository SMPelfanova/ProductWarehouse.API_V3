using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.EF.Constants;

namespace ProductWarehouse.Persistence.EF.Configurations;
public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        {
            builder.ToTable(nameof(TableNames.Roles));

            builder.HasKey(t => t.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        }
    }
}