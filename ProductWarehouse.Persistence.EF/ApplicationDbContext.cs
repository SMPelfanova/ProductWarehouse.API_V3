using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
namespace ProductWarehouse.Persistence.EF;
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext()
    {
        
    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Server=localhost;Database=newdatabase;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        //remove if it's working
        //modelBuilder.ApplyConfiguration(new ProductConfiguration());
        SeedData(modelBuilder);
    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<ProductGroups> ProductGroups { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<ProductSize> ProductSizes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<OrderStatus> OrderStatus { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }


    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>().HasData(
            new Brand { Id = Guid.NewGuid(), Name = "Zara" },
            new Brand { Id = Guid.NewGuid(), Name = "Bershka" },
            new Brand { Id = Guid.NewGuid(), Name = "Stella Nova" }
        );

        modelBuilder.Entity<Group>().HasData(
            new Group { Id = Guid.NewGuid(), Name = "Casual" },
            new Group { Id = Guid.NewGuid(), Name = "Comfortable" }
        );

        modelBuilder.Entity<OrderStatus>().HasData(
            new OrderStatus { Id = Guid.NewGuid(), Name = "Pending" },
            new OrderStatus { Id = Guid.NewGuid(), Name = "Delivered" }
        );

        modelBuilder.Entity<Size>().HasData(
            new Size { Id = Guid.NewGuid(), Name = "XS" },
            new Size { Id = Guid.NewGuid(), Name = "S" },
            new Size { Id = Guid.NewGuid(), Name = "M" },
            new Size { Id = Guid.NewGuid(), Name = "L" },
            new Size { Id = Guid.NewGuid(), Name = "XL" }
        );
    }
}
