namespace ProductWarehouse.Domain.Interfaces;
public interface IRepository<TEntity> where TEntity : class
{
    Task<IReadOnlyList<TEntity>> GetAllAsync(params string[] includeProperties);
    Task<TEntity> GetByIdAsync(Guid id);
    Task Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
