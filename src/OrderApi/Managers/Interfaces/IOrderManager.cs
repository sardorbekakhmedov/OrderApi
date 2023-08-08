using OrderApi.Entities;
using OrderApi.Models.OrderModels;

namespace OrderApi.Managers.Interfaces;

public interface IOrderManager
{
    public Task<Order> CreateOrderAsync(CreateOrderModel model);
    public IEnumerable<Order> GetOrdersAsync();
    public Task<Order> GetByIdAsync(Guid orderId);
    public Task<Order> UpdateAsync(Guid orderId, UpdateOrderModel model);
    public Task DeleteAsync(Guid orderId);
}