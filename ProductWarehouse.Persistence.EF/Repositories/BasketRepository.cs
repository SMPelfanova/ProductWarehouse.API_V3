using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using ProductWarehouse.Persistence.Abstractions.Exceptions;

namespace ProductWarehouse.Persistence.EF.Repositories;

public class BasketRepository : Repository<Basket>, IBasketRepository
{
	private readonly ApplicationDbContext _dbContext;

	public BasketRepository(ApplicationDbContext dbContext) : base(dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Basket> GetBasketByUserIdAsync(Guid userId)
	{
		try
		{
			return await _dbContext.Basket
						.Include(b => b.BasketLines)
						.SingleAsync(b => b.UserId == userId);
		}
		catch (InvalidOperationException ex)
		{
			throw new NotFoundException("Basket not found for the specified user.", ex);
		}
		catch (Exception ex)
		{
			throw new DatabaseException("An error occurred while fetching the basket.", ex);
		}
	}

	public async Task DeleteBasketLinesAsync(Guid userId)
	{
		try
		{
			var basket = await _dbContext.Basket
						.Include(b => b.BasketLines)
						.SingleAsync(x => x.UserId == userId);

			_dbContext.BasketLine.RemoveRange(basket.BasketLines);
		}
		catch (InvalidOperationException ex)
		{
			throw new NotFoundException("Basket not found for the specified user.", ex);
		}
		catch (Exception ex)
		{
			throw new DatabaseException("An error occurred while fetching the basket.", ex);
		}
	}
}