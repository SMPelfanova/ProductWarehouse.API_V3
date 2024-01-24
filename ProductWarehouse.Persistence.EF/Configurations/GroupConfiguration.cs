using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.EF.Constants;

namespace ProductWarehouse.Persistence.EF.Configurations;
public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable(TableNames.Groups);

        builder.HasKey(t => t.Id);

        builder.Property(p => p.Name).IsRequired();
    }
}
