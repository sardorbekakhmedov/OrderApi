using OrderApi.Entities.PageFilters;
using OrderApi.Models;
using OrderApi.Models.UserModels;

namespace OrderApi.Managers.Interfaces;

public interface IUserManager
{
    public Task<UserModel> CreateUserAsync(CreateUserModel model);
    public Task<IEnumerable<UserModel>> GetUsersAsync(UserFilter filter);
    public Task<TokenResultModel> LoginAsync(LoginUserModel model);
    public Task<UserModel> GetByIdAsync(Guid userId);
    public Task<UserModel> UpdateAsync(Guid userId, UpdateUserModel model);
    public Task DeleteAsync(Guid userId);
}