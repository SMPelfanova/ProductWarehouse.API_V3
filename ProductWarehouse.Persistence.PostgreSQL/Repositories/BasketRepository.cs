using Dapper;
using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using ProductWarehouse.Persistence.Abstractions.Exceptions;
using ProductWarehouse.Persistence.PostgreSQL.Constants;
using ProductWarehouse.Persistence.PostgreSQL.Constants.Dapper;
using Serilog;
using System.Data;

namespace ProductWarehouse.Persistence.PostgreSQL.Repositories;

public class BasketRepository : Repository<Baskets>, IBasketRepository
{
	private readonly ApplicationDbContext _dbContext;
	private readonly IDbConnection _dbConnection;
	private readonly ILogger _logger;

	public BasketRepository(
		ApplicationDbContext dbContext,
		IDbConnection dbConnection,
		IDbTransaction dbTransaction,
		ILogger logger) : base(dbContext, dbConnection, dbTransaction, logger)
	{
		_dbContext = dbContext;
		_dbConnection = dbConnection;
		_logger = logger;
	}

	public async Task<Baskets> GetBasketByUserIdAsync(Guid userId, CancellationToken cancellationToken)
	{
		Baskets currentBasket = null;
		try
		{
			var basketsLookup = new Dictionary<Guid, Baskets>();
			await _dbConnection.QueryAsync<Baskets, BasketLine, Baskets>(
				QueryConstants.GetBasketByUserIdQuery,
				(basket, basketLine) =>
				{
					if (currentBasket == null || currentBasket.Id != basket.Id)
					{
						currentBasket = basket;
						currentBasket.BasketLines = new List<BasketLine>();
						basketsLookup.Add(currentBasket.Id, currentBasket);
					}

					currentBasket.BasketLines.Add(basketLine);
					return currentBasket;
				},
				new { UserId = userId },
				splitOn: $"{nameof(Baskets.Id)}");

			currentBasket = basketsLookup.Values.FirstOrDefault();
		}
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(Baskets)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(Baskets)), ex);
		}

		if (currentBasket is null)
		{
			_logger.Warning(MessageConstants.NotFoundErrorMessage(nameof(Baskets)));
			throw new NotFoundException(MessageConstants.NotFoundErrorMessage(nameof(Baskets)));
		}

		return currentBasket;
	}

	public async Task DeleteBasketLinesAsync(Guid userId, CancellationToken cancellationToken)
	{
		try
		{
			var basket = await _dbContext.Baskets
						.AsNoTracking()
						.Include(b => b.BasketLines)
						.SingleAsync(x => x.UserId == userId, cancellationToken);

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