using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using ProductWarehouse.Persistence.Abstractions.Exceptions;

namespace ProductWarehouse.Persistence.EF.Repositories;

public class BasketLineRepository : Repository<BasketLine>, IBasketLineRepository
{
	private readonly ApplicationDbContext _dbContext;

	public BasketLineRepository(ApplicationDbContext dbContext) : base(dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<bool> GetByProductAndSizeAsync(Guid userId, Guid productId, Guid sizeId)
	{
		try
		{
			var basket = await _dbContext.Basket.SingleAsync(x => x.UserId == userId);
			return !basket.BasketLines.Any(x => x.ProductId == productId && x.SizeId == sizeId);
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