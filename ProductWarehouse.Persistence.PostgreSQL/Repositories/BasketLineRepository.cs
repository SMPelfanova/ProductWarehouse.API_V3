using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using ProductWarehouse.Persistence.Abstractions.Exceptions;
using ProductWarehouse.Persistence.PostgreSQL.Constants;
using Serilog;
using System.Data;

namespace ProductWarehouse.Persistence.PostgreSQL.Repositories;

public class BasketLineRepository : Repository<BasketLine>, IBasketLineRepository
{
	private readonly ApplicationDbContext _dbContext;
	private readonly IDbConnection _dbConection;
	private readonly ILogger _logger;

	public BasketLineRepository(
		ApplicationDbContext dbContext,
		IDbConnection dbConection,
		IDbTransaction dbTransaction,
		ILogger logger) : base(dbContext, dbConection, dbTransaction, logger)
	{
		_dbContext = dbContext;
		_dbConection = dbConection;
		_logger = logger;
	}

	public async Task<bool> CheckProductAndSizeAddedAsync(Guid userId, Guid productId, Guid sizeId, CancellationToken cancellationToken)
	{
		try
		{
			var basket = await _dbContext.Baskets
				.AsNoTracking()
				.Include(x => x.BasketLines)
				.SingleAsync(x => x.UserId == userId, cancellationToken);
			if (basket?.BasketLines == null)
			{
				return false;
			}
			return basket.BasketLines.Any(x => x.ProductId == productId && x.SizeId == sizeId);
		}
		catch (InvalidOperationException ex)
		{
			_logger.Warning(MessageConstants.NotFoundErrorMessage(nameof(BasketLine)), ex);
			throw new NotFoundException(MessageConstants.NotFoundErrorMessage(nameof(BasketLine)), ex);
		}
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(BasketLine)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(BasketLine)), ex);
		}
	}
}