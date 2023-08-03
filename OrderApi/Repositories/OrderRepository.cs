using OrderApi.Context;
using OrderApi.Entities;
using OrderApi.Models.OrderModels;
using OrderApi.Repositories.Interfaces;

namespace OrderApi.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderApiDbContext _dbContext;

    public OrderRepository(OrderApiDbContext dbContext)
    {
        _dbContext = dbContext;
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