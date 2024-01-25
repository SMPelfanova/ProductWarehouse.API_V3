using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Interfaces;
using ProductWarehouse.Persistence.EF;

namespace ProductWarehouse.Persistence.Repositories;
public abstract class Repository<TEntity> where TEntity : class
{
    protected readonly ApplicationDbContext _dbContext;

    protected Repository(ApplicationDbContext context)
    {
        _dbContext = context;
    }
    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public async Task Add(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }

    public void Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
    }
}