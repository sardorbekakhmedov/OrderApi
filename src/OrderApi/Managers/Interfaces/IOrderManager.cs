using OrderApi.Entities.PageFilters;
using OrderApi.Models.OrderModels;

namespace OrderApi.Managers.Interfaces;

public interface IOrderManager
{
    public Task<OrderModel> CreateOrderAsync(CreateOrderModel model);
    public Task<IEnumerable<OrderModel>> GetOrdersAsync(OrderFilter orderFilter);
    public Task<OrderModel> GetByIdAsync(Guid orderId);
    public Task<OrderModel> UpdateAsync(Guid orderId, UpdateOrderModel model);
    public Task DeleteAsync(Guid orderId);
}