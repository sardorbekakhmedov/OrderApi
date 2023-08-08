using OrderApi.Entities.PageFilters;
using OrderApi.Models.ProductModels;

namespace OrderApi.Managers.Interfaces;

public interface IProductManager
{
    public Task<ProductModel> CreateProductAsync(string categoryName, CreateProductModel model);
    public Task<IEnumerable<ProductModel>> GetProductsAsync(ProductFilter productFilter);
    public Task<ProductModel> GetByIdAsync(Guid productId);
    public Task<ProductModel> UpdateAsync(Guid productId, UpdateProductModel model);
    public Task DeleteAsync(Guid productId);
}