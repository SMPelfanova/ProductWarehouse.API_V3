using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using ProductWarehouse.Persistence.Abstractions.Exceptions;
using ProductWarehouse.Persistence.EF.Constants;
using Serilog;

namespace ProductWarehouse.Persistence.EF.Repositories;

public class BasketRepository : Repository<Baskets>, IBasketRepository
{
	private readonly ApplicationDbContext _dbContext;
	private readonly ILogger _logger;

	public BasketRepository(ApplicationDbContext dbContext, ILogger logger) : base(dbContext, logger)
	{
		_dbContext = dbContext;
		_logger = logger;
	}

	public async Task<Baskets> GetBasketByUserIdAsync(Guid userId)
	{
		try
		{
			return await _dbContext.Baskets
						.Include(b => b.BasketLines)
						.SingleAsync(b => b.UserId == userId);
		}
		catch (InvalidOperationException ex)
		{
			_logger.Warning(MessageConstants.NotFoundErrorMessage(nameof(Baskets)), ex);
			throw new NotFoundException(MessageConstants.NotFoundErrorMessage(nameof(Baskets)), ex);
		}
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(Baskets)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(Baskets)), ex);
		}
	}

	public void DeleteBasketLines(Guid userId)
	{
		try
		{
			var basket = _dbContext.Baskets
						.Include(b => b.BasketLines)
						.Single(x => x.UserId == userId);

			_dbContext.BasketLines.RemoveRange(basket.BasketLines);
		}
		catch (InvalidOperationException ex)
		{
			_logger.Warning(MessageConstants.NotFoundErrorMessage(nameof(Baskets)), ex);
			throw new NotFoundException(MessageConstants.NotFoundErrorMessage(nameof(Baskets)), ex);
		}
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(Baskets)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(Baskets)), ex);
		}
	}
}