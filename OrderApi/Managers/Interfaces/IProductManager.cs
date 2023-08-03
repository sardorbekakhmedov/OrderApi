using OrderApi.Entities;
using OrderApi.Models.ProductModels;

namespace OrderApi.Managers.Interfaces;

public interface IProductManager
{
    public Task<Product> CreateUserAsync(CreateProductModel model);
    public IEnumerable<Product> GetUsersAsync();
    public Task<Product> GetByIdAsync(Guid productId);
    public Task<Product> UpdateAsync(Guid productId);
    public Task DeleteAsync(Guid productId);
}