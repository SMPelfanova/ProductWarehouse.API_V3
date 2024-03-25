using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions.Interfaces;

namespace ProductWarehouse.Application.Interfaces;

public interface IUserRepository : IRepository<User>
{

	Task<User> CheckIfUserExistAsync(string email);
	Task<User> GetUserByEmailAsync(string email);

	Task DeleteUserRefreshToken(string email);
	Task<string> GetUserRefreshToken(string email);
	Task SetUserRefreshToken(string email, string refreshToken);
}