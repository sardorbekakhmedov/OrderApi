using OrderApi.Context;
using OrderApi.Entities;
using OrderApi.Models.ProductModels;
using OrderApi.Repositories.Interfaces;

namespace OrderApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly OrderApiDbContext _dbContext;

    public ProductRepository(OrderApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Product> CreateUserAsync(CreateProductModel model)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByIdAsync(Guid productId)
    {
        throw new NotImplementedException();
    }

    public Task<Product> UpdateAsync(Guid productId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid productId)
    {
        throw new NotImplementedException();
    }
}