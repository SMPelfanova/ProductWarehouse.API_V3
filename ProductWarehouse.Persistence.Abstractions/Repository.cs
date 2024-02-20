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

	public async Task<TEntity> GetByIdAsync(Guid id)
	{
		try
		{
			TEntity entity = await _dbContext.Set<TEntity>().FindAsync(id);
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

	public async Task<IReadOnlyList<TEntity>> GetAllAsync(params string[] includeProperties)
	{
		try
		{
			IQueryable<TEntity> query = _dbContext.Set<TEntity>();

			foreach (var includeProperty in includeProperties)
			{
				query = query.Include(includeProperty);
			}

			return await query.ToListAsync();
		}
		catch (Exception ex)
		{
			_logger.Error("An error occurred while fetching all entities.", ex);
			throw new DatabaseException("An error occurred while fetching all entities.", ex);
		}
	}

	public async Task<TEntity> Add(TEntity entity)
	{
		try
		{
			var entry = await _dbContext.Set<TEntity>().AddAsync(entity);

			return entry.Entity;
		}
		catch (Exception ex)
		{
			_logger.Error("An error occurred while adding the entity.", ex);
			throw new DatabaseException("An error occurred while adding the entity.", ex);
		}
	}

	public void Delete(TEntity entity)
	{
		try
		{
			_dbContext.Set<TEntity>().Remove(entity);
		}
		catch (InvalidOperationException ex)
		{
			_logger.Warning("Entity to be deleted not found.", ex);
			throw new NotFoundException("Entity to be deleted not found.", ex);
		}
		catch (Exception ex)
		{
			_logger.Error("An error occurred while deleting the entity.", ex);
			throw new DatabaseException("An error occurred while deleting the entity.", ex);
		}
	}

	public void Update(TEntity entity)
	{
		try
		{
			_dbContext.Set<TEntity>().Update(entity);
		}
		catch (InvalidOperationException ex)
		{
			_logger.Warning("Entity to be updated not found.", ex);
			throw new NotFoundException("Entity to be updated not found.", ex);
		}
		catch (Exception ex)
		{
			_logger.Error("An error occurred while updating the entity.", ex);
			throw new DatabaseException("An error occurred while updating the entity.", ex);
		}
	}

	public async Task<bool> ExistsAsync(Guid id)
	{
		try
		{
			TEntity entity = await _dbContext.Set<TEntity>().FindAsync(id);
			return entity != null;
		}
		catch (Exception ex)
		{
			_logger.Error("An error occurred while checking if the entity exists by id.", ex);
			throw new DatabaseException("An error occurred while checking if the entity exists by id.", ex);
		}
	}
}