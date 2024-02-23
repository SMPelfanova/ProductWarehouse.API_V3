namespace ProductWarehouse.Persistence.Abstractions.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
	Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);
	Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken, params string[] includeProperties);
	Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
	Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
	Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
	Task<bool> CheckIfExistsAsync(Guid id, CancellationToken cancellationToken);
}