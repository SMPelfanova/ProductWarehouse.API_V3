using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Persistence.Abstractions.Exceptions;
using ProductWarehouse.Persistence.Abstractions.Interfaces;
using Serilog;

namespace ProductWarehouse.Persistence.Abstractions;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
	protected readonly DbContext _dbContext;
	private readonly ILogger _logger;

	protected Repository(DbContext context, ILogger logger)
	{
		_dbContext = context;
		_logger = logger;
	}

	public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
	{
		try
		{
			var entity = await _dbContext.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
			if (entity == null)
			{
				_logger.Warning($"Entity of type {typeof(TEntity)} with id {id} not found.");
				throw new NotFoundException($"Entity of type {typeof(TEntity)} with id {id} not found.");
			}
			return entity;
		}
		catch (Exception ex)
		{
			_logger.Error("An error occurred while fetching the entity by id.", ex);
			throw new DatabaseException("An error occurred while fetching the entity by id.", ex);
		}
	}

	public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default, params string[] includeProperties)
	{
		try
		{
			IQueryable<TEntity> query = _dbContext.Set<TEntity>();
			foreach (var includeProperty in includeProperties)
			{
				query = query.Include(includeProperty);
			}
			return await query.ToListAsync(cancellationToken);
		}
		catch (Exception ex)
		{
			_logger.Error("An error occurred while fetching all entities.", ex);
			throw new DatabaseException("An error occurred while fetching all entities.", ex);
		}
	}

	public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
	{
		try
		{
			var entry = await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
			return entry.Entity;
		}
		catch (Exception ex)
		{
			_logger.Error("An error occurred while adding the entity.", ex);
			throw new DatabaseException("An error occurred while adding the entity.", ex);
		}
	}

	public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
	{
		try
		{
			_dbContext.Set<TEntity>().Remove(entity);
			return Task.CompletedTask;
		}
		catch (Exception ex)
		{
			_logger.Error("An error occurred while deleting the entity.", ex);
			throw new DatabaseException("An error occurred while deleting the entity.", ex);
		}
	}

	public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
	{
		try
		{
			_dbContext.Set<TEntity>().Update(entity);
			return Task.CompletedTask;
		}
		catch (Exception ex)
		{
			_logger.Error("An error occurred while updating the entity.", ex);
			throw new DatabaseException("An error occurred while updating the entity.", ex);
		}
	}

	public async Task<bool> CheckIfExistsAsync(Guid id, CancellationToken cancellationToken = default)
	{
		try
		{
			var entity = await _dbContext.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
			return entity != null;
		}
		catch (Exception ex)
		{
			_logger.Error("An error occurred while checking if the entity exists by id.", ex);
			throw new DatabaseException("An error occurred while checking if the entity exists by id.", ex);
		}
	}
}