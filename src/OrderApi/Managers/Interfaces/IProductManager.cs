using OrderApi.Models.ProductModels;

namespace OrderApi.Managers.Interfaces;

public interface IProductManager
{
    public Task<ProductModel> CreateUserAsync(Guid categoryId, CreateProductModel model);
    public IEnumerable<ProductModel> GetUsersAsync();
    public Task<ProductModel> GetByIdAsync(Guid productId);
    public Task<ProductModel> UpdateAsync(Guid productId, UpdateProductModel model);
    public Task DeleteAsync(Guid productId);
}