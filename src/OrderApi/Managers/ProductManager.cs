using OrderApi.Entities;
using OrderApi.Entities.PageFilters;
using OrderApi.Exceptions;
using OrderApi.Extensions.EntityExtensions;
using OrderApi.Managers.Interfaces;
using OrderApi.Models.ProductModels;
using OrderApi.Repositories;
using OrderApi.Repositories.Interfaces;

namespace OrderApi.Managers;

public class ProductManager : IProductManager
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ProductManager(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<ProductModel> CreateProductAsync(string categoryName, CreateProductModel model)
    {
        var category = await _categoryRepository.GetByCategoryNameAsync(categoryName) ??
                       throw new ObjectNotFoundException(nameof(Category));

        var product = new Product
        {
            CategoryId = category.Id,
            ProductName = model.ProductName,
            Description = model.ProductDescription,
            UnitPrice = model.UnitPrice,
            UnitInStock = model.UnitInStock,
            Discontinued = false,
        };

        await _productRepository.AddAsync(product);
        return product.ToProductModel();
    }

    public async Task<IEnumerable<ProductModel>> GetProductsAsync(ProductFilter productFilter)
    {
        var products = await _productRepository.GetProductsAsync(productFilter);
        return products.Select(p => p.ToProductModel());
    }

    public async Task<ProductModel> GetByIdAsync(Guid productId)
    {
        var product = await _productRepository.GetByIdAsync(productId) 
                      ?? throw new ObjectNotFoundException(nameof(Product));

        return product.ToProductModel();
    }

    public async Task<ProductModel> UpdateAsync(Guid productId, UpdateProductModel model)
    {
        var product = await _productRepository.GetByIdAsync(productId)
                      ?? throw new ObjectNotFoundException(nameof(Product));

        product.CategoryId = model.CategoryId ?? product.CategoryId;
        product.ProductName = model.ProductName ?? product.ProductName;
        product.Description = model.ProductDescription ?? product.Description;
        product.UnitPrice = model.UnitPrice ?? product.UnitPrice;
        product.UnitInStock = model.UnitInStock ?? product.UnitInStock;
        product.Discontinued = model.Discontinued ?? product.Discontinued;
        product.Discontinued = model.Discontinued ?? product.Discontinued;

        var updateProduct = await _productRepository.UpdateAsync(product);
        return updateProduct.ToProductModel();
    }

    public async Task DeleteAsync(Guid productId)
    {
        var product = await _productRepository.GetByIdAsync(productId)
                      ?? throw new ObjectNotFoundException(nameof(Product));

        await _productRepository.RemoveAsync(product);
    }
}