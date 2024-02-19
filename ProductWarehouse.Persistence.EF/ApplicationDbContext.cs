using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.EF.SeedModels;
using System.Reflection;

namespace ProductWarehouse.Persistence.EF;

public class ApplicationDbContext : DbContext
{
 
	public ApplicationDbContext(DbContextOptions options) : base(options)
	{
	}

	public static void EnsureDatabaseCreated(DbContextOptions options)
	{
		using var context = new ApplicationDbContext(options);
		context.Database.Migrate();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		DataSeeder.SeedData(modelBuilder);
		base.OnModelCreating(modelBuilder);
	}

	public DbSet<Brand> Brands { get; set; }
	public DbSet<Product> Products { get; set; }
	public DbSet<Group> Groups { get; set; }
	public DbSet<ProductGroups> ProductGroups { get; set; }
	public DbSet<Size> Sizes { get; set; }
	public DbSet<ProductSize> ProductSizes { get; set; }
	public DbSet<User> Users { get; set; }
	public DbSet<UserRole> UserRoles { get; set; }
	public DbSet<Payment> Payments { get; set; }
	public DbSet<OrderStatus> OrderStatus { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<OrderLine> OrderLines { get; set; }
	public DbSet<Baskets> Baskets { get; set; }
	public DbSet<BasketLine> BasketLines { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
	}
}