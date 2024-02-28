using Dapper;
using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Persistence.Abstractions.Constants;
using ProductWarehouse.Persistence.Abstractions.Exceptions;
using ProductWarehouse.Persistence.Abstractions.Interfaces;
using Serilog;
using System.Data;

namespace ProductWarehouse.Persistence.Abstractions;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
	protected readonly DbContext _dbContext;
	private readonly IDbConnection _connection;
	private readonly ILogger _logger;

	protected Repository(DbContext context, IDbConnection connection, IDbTransaction dbTransaction, ILogger logger)
	{
		_dbContext = context;
		_connection = connection ?? throw new ArgumentNullException(nameof(connection));
		_logger = logger;
	}

	public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
	{
		TEntity? entity;
		try
		{
			var query = QueryConstants.SelectEntityById(typeof(TEntity).Name);
			entity = await _connection.QueryFirstOrDefaultAsync<TEntity>(query, new { Id = id });
			
		}
		catch (Exception ex)
		{
			_logger.Error("An error occurred while fetching the entity by id.", ex);
			throw new DatabaseException("An error occurred while fetching the entity by id.", ex);
		}
		if (entity is null)
		{
			_logger.Warning($"Entity of type {typeof(TEntity)} with id {id} not found.");
			throw new NotFoundException($"Entity of type {typeof(TEntity)} not found.");
		}
	
		return entity;
	}

	public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken)
	{
		try
		{
			var entities = await _connection.QueryAsync<TEntity>(QueryConstants.SelectEntity(typeof(TEntity).Name));
			return entities.ToList().AsReadOnly();
		}
		catch (Exception ex)
		{
			_logger.Error("An error occurred while fetching all entities.", ex);
			throw new DatabaseException("An error occurred while fetching all entities.", ex);
		}
	}

	public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
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

	public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
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

	public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
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

	public async Task<bool> CheckIfExistsAsync(Guid id, CancellationToken cancellationToken)
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