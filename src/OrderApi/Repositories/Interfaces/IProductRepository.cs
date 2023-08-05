using OrderApi.Entities;
using OrderApi.Entities.PageFilters;
using OrderApi.Repositories.GenericRepository;

namespace OrderApi.Repositories.Interfaces;

public interface IProductRepository : IGenericRepository<Product>
{
    public Task<IEnumerable<Product>> GetProductsAsync(ProductFilter filter);
}