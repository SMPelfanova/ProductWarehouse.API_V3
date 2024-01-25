using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.EF.Constants;

namespace ProductWarehouse.Persistence.EF.Configurations;
public class ProductGroupConfiguration : IEntityTypeConfiguration<ProductGroups>
{
    public void Configure(EntityTypeBuilder<ProductGroups> builder)
    {
        builder.ToTable(nameof(TableNames.ProductGroups));

        builder.HasKey(pg => new { pg.ProductId, pg.GroupId });
        
        builder.HasOne(pg => pg.Product)
            .WithMany(pg => pg.ProductGroups)
            .HasForeignKey(pg => pg.ProductId);
        
        builder.HasOne(pg => pg.Group)
            .WithMany(pg => pg.ProductGroups)
            .HasForeignKey(pg => pg.GroupId);
    }
}
