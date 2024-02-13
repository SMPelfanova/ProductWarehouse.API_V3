using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;

namespace ProductWarehouse.Persistence.EF.Repositories;

public sealed class OrderRepository : Repository<Order>, IOrderRepository
{
	private readonly ApplicationDbContext _dbContext;

	public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Order> GetOrderDetailsAsync(Guid id)
	{
		var order = await _dbContext.Orders
			.Where(o => o.Id == id)
			.Include(o => o.OrderLines)
			.Include(o => o.Status)
			.FirstOrDefaultAsync();

		return order;
	}

	public async Task<List<Order>> GetOrdersByUserIdAsync(Guid userId)
	{
		var orders = await _dbContext.Orders
		  .Where(o => o.UserId == userId && !o.IsDeleted)
		  .Include(o => o.Status)
		  .Include(o => o.OrderLines)
		  .ToListAsync();

		return orders;
	}
}