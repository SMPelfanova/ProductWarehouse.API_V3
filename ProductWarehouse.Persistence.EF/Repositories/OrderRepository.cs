using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using ProductWarehouse.Persistence.Abstractions.Exceptions;
using ProductWarehouse.Persistence.EF.Constants;
using Serilog;

namespace ProductWarehouse.Persistence.EF.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
	private readonly ApplicationDbContext _dbContext;
	private readonly ILogger _logger;

	public OrderRepository(ApplicationDbContext dbContext, ILogger logger) : base(dbContext, logger)
	{
		_dbContext = dbContext;
		_logger = logger;
	}

	public async Task<Order> GetOrderDetailsAsync(Guid id)
	{
		try
		{
			return await _dbContext.Orders
						.Include(o => o.OrderLines)
						.Include(o => o.Status)
						.SingleAsync(o => o.Id == id && !o.IsDeleted);
		}
		catch (InvalidOperationException ex)
		{
			_logger.Warning(MessageConstants.NotFoundErrorMessage(nameof(Order), id), ex);
			throw new NotFoundException(MessageConstants.NotFoundErrorMessage(nameof(Order), id), ex);
		}
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(Order)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(Order)), ex);
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
			_logger.Warning(MessageConstants.NotFoundErrorMessage(nameof(Order)), ex);
			throw new NotFoundException(MessageConstants.NotFoundErrorMessage(nameof(Order)), ex);
		}
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(Order)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(Order)), ex);
		}
	}
}