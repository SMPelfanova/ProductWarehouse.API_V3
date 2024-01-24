namespace ProductWarehouse.Domain.Interfaces;
public interface IRepository<TEntity> where TEntity : class
{
    Task<IReadOnlyList<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity);
}
