using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Persistence.EF.Extensions;

public static class ModelBuilderExtensions
{
	public static void Seed(this ModelBuilder modelBuilder)
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

		modelBuilder.Entity<Baskets>().HasData(
			new Baskets
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