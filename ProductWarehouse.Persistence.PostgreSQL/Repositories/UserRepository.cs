using Dapper;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using ProductWarehouse.Persistence.PostgreSQL.Constants.Dapper;
using Serilog;
using System.Data;
using static ProductWarehouse.Persistence.PostgreSQL.Constants.Dapper.MutateConstants;

namespace ProductWarehouse.Persistence.PostgreSQL.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
	private readonly IDbConnection _dbConnection;

	public UserRepository(ApplicationDbContext dbContext, IDbConnection dbConnection, ILogger logger) : base(dbContext, dbConnection, logger)
	{
		_dbConnection = dbConnection;
	}

	public async Task<User> CheckIfUserExistAsync(string email)
	{
		var user = await _dbConnection.QueryFirstOrDefaultAsync<User>(
		   ReadContants.UserReadQueriesConstants.CheckUserExistQuery,
		   new { Email = email }
	   );

		return user;
	}

	public async Task<User> GetUserByEmailAsync(string email)
	{
		var lookup = new Dictionary<Guid, User>();

		await _dbConnection.QueryAsync<User, Role, User>(ReadContants.UserReadQueriesConstants.GetUserByEmailQuery,
			(user, role) =>
			{
				if (!lookup.TryGetValue(user.Id, out var userEntry))
				{
					userEntry = user;
					userEntry.UserRoles = new List<UserRole>();
					lookup.Add(userEntry.Id, userEntry);
				}
				userEntry.UserRoles ??= new List<UserRole>();
				userEntry.UserRoles.Add(new UserRole { UserId = user.Id, RoleId = role.Id, Role = new Role
				{
					Id = user.Id,
					Name = role.Name
				} });

				return userEntry;
			},
			new { Email = email },

			splitOn: "Id"
		);

		return lookup.Values.SingleOrDefault();
	}

	public async Task<string> GetUserRefreshToken(string email)
	{
		string refreshToken = await _dbConnection.QuerySingleOrDefault(ReadContants.UserReadQueriesConstants.GetUserRefreshTokenQuery, new { Email = email });
		return refreshToken;
	}

	public async Task SetUserRefreshToken(string email, string refreshToken)
	{
		await _dbConnection.ExecuteAsync(MutateConstants.UserUpdateQueriesConstants.SetUserRefreshToken, 
			new { Email = email, 
				RefreshToken = refreshToken,
				RefreshTokenExpiresAt = DateTime.Now.AddMinutes(2) 
			});

	}

	public async Task DeleteUserRefreshToken(string email)
	{
		await _dbConnection.ExecuteAsync(MutateConstants.UserUpdateQueriesConstants.DeleteUserRefreshToken, new { Email = email });
	}

}