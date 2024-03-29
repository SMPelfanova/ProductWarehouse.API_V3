﻿using Dapper;
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

	protected Repository(DbContext context, IDbConnection connection, ILogger logger)
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
			var query = QueryConstants.SelectEntityById(GetEntityName());
			entity = await _connection.QuerySingleAsync<TEntity>(query, new { Id = id });
		}
		catch(InvalidOperationException ex)
		{
			_logger.Warning($"Entity of type {typeof(TEntity)} with id {id} not found.");
			throw new NotFoundException($"Entity of type {typeof(TEntity)} not found.");
		}
		catch (Exception ex)
		{
			_logger.Error("An error occurred while fetching the entity by id.", ex);
			throw new DatabaseException("An error occurred while fetching the entity by id.", ex);
		}
	
		return entity;
	}

	public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken)
	{
		IEnumerable<TEntity?> entities;
		try
		{
			entities = await _connection.QueryAsync<TEntity>(QueryConstants.SelectEntity(GetEntityName()));
		}
		catch (Exception ex)
		{
			_logger.Error("An error occurred while fetching all entities.", ex);
			throw new DatabaseException("An error occurred while fetching all entities.", ex);
		}
		if (entities is null)
		{
			_logger.Warning($"Entities of type {typeof(TEntity)} not found.");
			throw new NotFoundException($"Entities of type {typeof(TEntity)} not found.");
		}

		return entities.ToList().AsReadOnly();
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
			return entity is not null;
		}
		catch (Exception ex)
		{
			_logger.Error("An error occurred while checking if the entity exists by id.", ex);
			throw new DatabaseException("An error occurred while checking if the entity exists by id.", ex);
		}
	}

	private string GetEntityName()
	{
		var entityName = typeof(TEntity).Name;
		if (entityName == Constants.Constants.OrderStatus)
		{
			return entityName;
		}
		return entityName.EndsWith("s") ? entityName + "es" : entityName + "s";
	}
}