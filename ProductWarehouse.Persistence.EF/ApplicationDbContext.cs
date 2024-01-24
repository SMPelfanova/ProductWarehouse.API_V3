using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Domain.Interfaces;
using ProductWarehouse.Persistence.EF.Configurations;

namespace ProductWarehouse.Persistence.EF;
internal class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        //remove if it's working
        //modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }

    public void Commit()
    {
        throw new NotImplementedException();
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        throw new NotImplementedException();
    }

    public void Rallback()
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChanges(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
