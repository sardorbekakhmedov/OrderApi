using OrderApi.Context;
using OrderApi.Entities;
using OrderApi.Models.CategoryModels;
using OrderApi.Repositories.Interfaces;

namespace OrderApi.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly OrderApiDbContext _dbContext;

    public CategoryRepository(OrderApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Category> CreateUserAsync(CreateCategoryModel model)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Category> GetUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetByIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<Category> UpdateAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}