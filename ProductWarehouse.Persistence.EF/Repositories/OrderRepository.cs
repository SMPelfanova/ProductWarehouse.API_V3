using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using ProductWarehouse.Persistence.Abstractions.Exceptions;

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
		try
		{
			return await _dbContext.Orders
						.Include(o => o.OrderLines)
						.Include(o => o.Status)
						.SingleAsync(o => o.Id == id);
		}
		catch (InvalidOperationException ex)
		{
			throw new NotFoundException($"Order with specified id: {id} not found.", ex);
		}
		catch (Exception ex)
		{
			throw new DatabaseException("An error occurred while fetching the basket.", ex);
		}

	}

	public async Task<List<Order>> GetOrdersByUserIdAsync(Guid userId)
	{
		try
		{
			return await _dbContext.Orders
			  .Where(o => o.UserId == userId && !o.IsDeleted)
			  .Include(o => o.Status)
			  .Include(o => o.OrderLines)
			  .ToListAsync();
		}
		catch (InvalidOperationException ex)
		{
			throw new NotFoundException("Orders not found for the specified user.", ex);
		}
		catch (Exception ex)
		{
			throw new DatabaseException("An error occurred while fetching the basket.", ex);
		}
	}
}