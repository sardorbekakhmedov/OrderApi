using OrderApi.Entities;
using OrderApi.Models.UserModels;

namespace OrderApi.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<User> CreateUserAsync(CreateUserModel model);
    public IEnumerable<User> GetUsersAsync();
    public Task<User> GetByIdAsync(Guid userId);
    public Task<User> UpdateAsync(Guid userId);
    public Task DeleteAsync(Guid userId);
}