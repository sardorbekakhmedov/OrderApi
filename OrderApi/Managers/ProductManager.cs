using OrderApi.Entities;
using OrderApi.Managers.Interfaces;
using OrderApi.Models.ProductModels;
using OrderApi.Repositories.Interfaces;

namespace OrderApi.Managers;

public class ProductManager : IProductManager
{
    private readonly IProductRepository _productRepository;

    public ProductManager(IProductRepository productRepository)
    {
        _productRepository = productRepository;
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