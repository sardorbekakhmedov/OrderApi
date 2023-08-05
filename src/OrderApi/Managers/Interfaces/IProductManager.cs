using OrderApi.Models.ProductModels;

namespace OrderApi.Managers.Interfaces;

public interface IProductManager
{
    public Task<ProductModel> CreateProductAsync(Guid categoryId, CreateProductModel model);
    public IEnumerable<ProductModel> GetProductsAsync();
    public Task<ProductModel> GetByIdAsync(Guid productId);
    public Task<ProductModel> UpdateAsync(Guid productId, UpdateProductModel model);
    public Task DeleteAsync(Guid productId);
}