using OrderApi.Entities;
using OrderApi.Models.ProductModels;

namespace OrderApi.Repositories.Interfaces;

public interface IProductRepository
{
    public Task<Product> CreateUserAsync(CreateProductModel model);
    public IEnumerable<Product> GetUsersAsync();
    public Task<Product> GetByIdAsync(Guid productId);
    public Task<Product> UpdateAsync(Guid productId);
    public Task DeleteAsync(Guid productId);
}