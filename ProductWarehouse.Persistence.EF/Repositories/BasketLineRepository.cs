using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using ProductWarehouse.Persistence.Abstractions.Exceptions;
using Serilog;

namespace ProductWarehouse.Persistence.EF.Repositories;

public class BasketLineRepository : Repository<BasketLine>, IBasketLineRepository
{
	private readonly ApplicationDbContext _dbContext;
	private readonly ILogger _logger;

	public BasketLineRepository(ApplicationDbContext dbContext, ILogger logger) : base(dbContext, logger)
	{
		_dbContext = dbContext;
		_logger = logger;
	}

	public async Task<bool> CheckProductAndSizeAddedAsync(Guid userId, Guid productId, Guid sizeId)
	{
		try
		{
			var basket = await _dbContext.Baskets.Include(x => x.BasketLines).SingleAsync(x => x.UserId == userId);
			if (basket?.BasketLines == null)
			{
				return false;
			}
			return basket.BasketLines.Any(x => x.ProductId == productId && x.SizeId == sizeId);
		}
		catch (InvalidOperationException ex)
		{
			_logger.Warning("Basket not found for the specified user.", ex);
			throw new NotFoundException("Basket not found for the specified user.", ex);
		}
		catch (Exception ex)
		{
			_logger.Error("An error occurred while fetching the basket.", ex);
			throw new DatabaseException("An error occurred while fetching the basket.", ex);
		}
	}
}