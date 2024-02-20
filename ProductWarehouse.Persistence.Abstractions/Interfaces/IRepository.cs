namespace ProductWarehouse.Persistence.Abstractions.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
	Task<IReadOnlyList<TEntity>> GetAllAsync(params string[] includeProperties);

	Task<TEntity> GetByIdAsync(Guid id);

	Task<TEntity> Add(TEntity entity);

	void Update(TEntity entity);

	void Delete(TEntity entity);

	Task<bool> ExistsAsync(Guid id);
}