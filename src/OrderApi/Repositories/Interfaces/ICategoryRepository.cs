using OrderApi.Entities;
using OrderApi.Entities.PageFilters;
using OrderApi.Repositories.GenericRepository;

namespace OrderApi.Repositories.Interfaces;

public interface ICategoryRepository : IGenericRepository<Category>
{
    public Task<IEnumerable<Category>> GetCategoriesAsync(CategoryFilter filter);
    Task<Category?> GetByCategoryNameAsync(string categoryName);
}