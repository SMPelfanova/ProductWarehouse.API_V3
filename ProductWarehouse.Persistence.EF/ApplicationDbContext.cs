using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Domain.Entities;

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
		if (!optionsBuilder.IsConfigured)
		{
			optionsBuilder.UseSqlServer("Server=localhost;Database=Werehouse;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
		}
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

		SeedData(modelBuilder);
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

	private void SeedData(ModelBuilder modelBuilder)
	{
		Guid userid = Guid.NewGuid();
		modelBuilder.Entity<User>().HasData(
			new User
			{
				Id = userid,
				FirstName = "First",
				LastName = "Last",
				Password = "asd",
				Phone = "0888888877",
				Email = "test@email.com",
				Address = "Street default"
			});

		modelBuilder.Entity<Basket>().HasData(
			new Basket
			{
				Id = Guid.NewGuid(),
				UserId = userid
			});

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