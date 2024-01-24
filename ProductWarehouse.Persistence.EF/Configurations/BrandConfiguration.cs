using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.EF.Constants;

namespace ProductWarehouse.Persistence.EF.Configurations;
public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable(TableNames.Brands);

        builder.HasKey(t => t.Id);

        builder.Property(p => p.Name).IsRequired();
    }
}
