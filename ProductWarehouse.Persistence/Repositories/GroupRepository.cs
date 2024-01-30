using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.EF;

namespace ProductWarehouse.Persistence.Repositories;

public sealed class GroupRepository : Repository<Group>, IGroupRepository
{
    public GroupRepository(ApplicationDbContext dbContext):base(dbContext)
    {
    }
}