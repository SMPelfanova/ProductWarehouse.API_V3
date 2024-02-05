using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.EF.Constants;

namespace ProductWarehouse.Persistence.EF.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(TableNames.Users));

        builder.HasKey(p => p.Id);

        builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Email).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Password).IsRequired();
        builder.Property(p => p.Phone).IsRequired().HasMaxLength(20);
        builder.Property(p => p.Address).IsRequired().HasMaxLength(255);

        builder.HasOne(b => b.Basket)
        .WithOne(p => p.User)
        .HasForeignKey<Basket>(b => b.UserId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
