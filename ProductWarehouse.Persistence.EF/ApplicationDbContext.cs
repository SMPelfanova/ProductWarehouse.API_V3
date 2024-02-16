using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.EF.SeedModels;
using System;

namespace ProductWarehouse.Persistence.EF;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext()
	{
	}

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.EnableSensitiveDataLogging();
		if (!optionsBuilder.IsConfigured)
		{
			optionsBuilder.UseSqlServer("Server=localhost;Database=Werehouse;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
		}
	}
	public static void EnsureDatabaseCreated(DbContextOptions<ApplicationDbContext> options)
	{
		using var context = new ApplicationDbContext(options);
		context.Database.EnsureCreated();
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

		DataSeeder.SeedData(modelBuilder);
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
	public DbSet<OrderLine> OrderLine { get; set; }
	public DbSet<Basket> Basket { get; set; }
	public DbSet<BasketLine> BasketLine { get; set; }
}