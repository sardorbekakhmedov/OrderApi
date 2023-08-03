using OrderApi.Entities;
using OrderApi.Managers.Interfaces;
using OrderApi.Models.OrderModels;
using OrderApi.Repositories.Interfaces;

namespace OrderApi.Managers;

public class OrderManager : IOrderManager
{
    private readonly IOrderRepository _orderRepository;

    public OrderManager(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task<Order> CreateUserAsync(CreateOrderModel model)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Order> GetUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Order> GetByIdAsync(Guid orderId)
    {
        throw new NotImplementedException();
    }

    public Task<Order> UpdateAsync(Guid orderId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid orderId)
    {
        throw new NotImplementedException();
    }
}