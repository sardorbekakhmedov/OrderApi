using OrderApi.Entities;
using OrderApi.Entities.PageFilters;
using OrderApi.Repositories.GenericRepository;

namespace OrderApi.Repositories.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<IEnumerable<User>> GetUsersAsync(UserFilter filter);
    Task<User?> GetByUsernameAsync(string username);
}