﻿using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using Serilog;

namespace ProductWarehouse.Persistence.EF.Repositories;

public class GroupRepository : Repository<Group>, IGroupRepository
{
	public GroupRepository(ApplicationDbContext dbContext, ILogger logger) : base(dbContext, logger)
	{
	}
}