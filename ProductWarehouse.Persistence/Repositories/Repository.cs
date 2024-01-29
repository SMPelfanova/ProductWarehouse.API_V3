using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Domain.Interfaces;
using ProductWarehouse.Persistence.EF;

namespace ProductWarehouse.Persistence.Repositories;
public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly ApplicationDbContext _dbContext;

    protected Repository(ApplicationDbContext context)
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

    public async Task Add(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }

    //public void Delete(Guid id)
    //{
    //    var entity = _dbContext.Set<TEntity>().FindAsync(id);
    //    Delete(entity);
    //}

    public void Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
    }
}