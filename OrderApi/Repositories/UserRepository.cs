using OrderApi.Context;
using OrderApi.Entities;
using OrderApi.Models.UserModels;
using OrderApi.Repositories.Interfaces;

namespace OrderApi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly OrderApiDbContext _dbContext;

    public UserRepository(OrderApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<User> CreateUserAsync(CreateUserModel model)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}