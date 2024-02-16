using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Persistence.Abstractions.Exceptions;
using ProductWarehouse.Persistence.Abstractions.Interfaces;

namespace ProductWarehouse.Persistence.Abstractions;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
	protected readonly DbContext _dbContext;

	protected Repository(DbContext context)
	{
		_dbContext = context;
	}

	public async Task<TEntity> GetByIdAsync(Guid id)
	{
		try
		{
			TEntity entity = await _dbContext.Set<TEntity>().FindAsync(id);
			if (entity == null)
			{
				throw new NotFoundException($"Entity of type {typeof(TEntity)} with id {id} not found.");
			}

			return entity;
		}
		catch (Exception ex)
		{
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
			throw new DatabaseException("An error occurred while fetching all entities.", ex);
		}
	}

	//todo: fix 
	public async Task<Guid> Add(TEntity entity)
	{
		try
		{
			var entry = await _dbContext.Set<TEntity>().AddAsync(entity);
			await _dbContext.SaveChangesAsync();

			var idProperty = entity.GetType().GetProperty("Id");
			if (idProperty == null || idProperty.PropertyType != typeof(Guid))
			{
				return Guid.Empty;
			}

			var generatedId = _dbContext.Entry(entity).Property("Id").CurrentValue;

			return (Guid)generatedId;
		}
		catch (Exception ex)
		{
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
			throw new NotFoundException("Entity to be deleted not found.", ex);
		}
		catch (Exception ex)
		{
			throw new DatabaseException("An error occurred while deleting the entity.", ex);
		}
	}

	//todo: make async Delete and Update
	public void Update(TEntity entity)
	{
		try
		{
			_dbContext.Set<TEntity>().Update(entity);
		}
		catch (InvalidOperationException ex)
		{
			throw new NotFoundException("Entity to be updated not found.", ex);
		}
		catch (Exception ex)
		{
			throw new DatabaseException("An error occurred while updating the entity.", ex);
		}
	}
}