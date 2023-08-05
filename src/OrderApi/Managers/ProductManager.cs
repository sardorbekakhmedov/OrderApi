using OrderApi.Entities;
using OrderApi.Extensions.EntityExtensions;
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

    public async Task<ProductModel> CreateUserAsync(Guid categoryId, CreateProductModel model)
    {
        var product = new Product()
        {
            CategoryId = categoryId,
            ProductName = model.ProductName,
            Description = model.ProductDescription,
            UnitPrice = model.UnitPrice,
            UnitInStock = model.UnitInStock,
            CreatedAt = DateTime.UtcNow,
            Discontinued = false,
        };

        await _productRepository.AddAsync(product);
        return product.ToProductModel();
    }

    public IEnumerable<ProductModel> GetUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProductModel> GetByIdAsync(Guid productId)
    {
        throw new NotImplementedException();
    }

    public Task<ProductModel> UpdateAsync(Guid productId, UpdateProductModel model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid productId)
    {
        throw new NotImplementedException();
    }
}