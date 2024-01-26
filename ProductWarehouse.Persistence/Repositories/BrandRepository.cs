using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Domain.Interfaces;
using ProductWarehouse.Infrastructure.Http;
using ProductWarehouse.Persistence.EF;

namespace ProductWarehouse.Persistence.Repositories;

public sealed class BrandRepository : Repository<Brand>, IBrandRepository
{
    public BrandRepository(ApplicationDbContext dbContext):base(dbContext)
    {
    }
}