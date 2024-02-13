using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;

namespace ProductWarehouse.Persistence.EF.Repositories;

public sealed class GroupRepository : Repository<Group>, IGroupRepository
{
	public GroupRepository(ApplicationDbContext dbContext) : base(dbContext)
	{
	}
}