using OrderApi.Entities;
using OrderApi.Entities.PageFilters;
using OrderApi.Repositories.GenericRepository;

namespace OrderApi.Repositories.Interfaces;

public interface IOrderRepository : IGenericRepository<Order>
{
    public Task<IEnumerable<Order>> GetUsersAsync(OrderFilter filter);
 
}