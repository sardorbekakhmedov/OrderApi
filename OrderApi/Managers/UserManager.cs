using OrderApi.Entities;
using OrderApi.Managers.Interfaces;
using OrderApi.Models.UserModels;
using OrderApi.Repositories.Interfaces;

namespace OrderApi.Managers;

public class UserManager : IUserManager
{
    private readonly IUserRepository _userRepository;

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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