using Microsoft.EntityFrameworkCore;
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
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(params string[] includeProperties)
    {
        IQueryable<TEntity> query = _dbContext.Set<TEntity>();

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        return await query.ToListAsync();
    }

    public async Task<Guid> Add(TEntity entity)
    {
        var entry = await _dbContext.Set<TEntity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        var generatedId = _dbContext.Entry(entity).Property("Id").CurrentValue;

        return (Guid)generatedId;
    }
    public void Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }

    public void Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
    }
}