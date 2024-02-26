namespace ProductWarehouse.Persistence.Abstractions.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
	Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
	Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
	Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
	Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
	Task<bool> CheckIfExistsAsync(Guid id, CancellationToken cancellationToken = default);
}