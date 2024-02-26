using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using Serilog;
using System.Data;

namespace ProductWarehouse.Persistence.PostgreSQL.Repositories;

public class GroupRepository : Repository<Group>, IGroupRepository
{
	public GroupRepository(ApplicationDbContext dbContext, IDbConnection dbConection, IDbTransaction dbTransaction, ILogger logger) : base(dbContext, dbConection, dbTransaction, logger)
	{
	}
}