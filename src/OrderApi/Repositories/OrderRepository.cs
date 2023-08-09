using OrderApi.Context;
using OrderApi.Entities;
using OrderApi.Entities.PageFilters;
using OrderApi.Entities.PaginationEntities;
using OrderApi.Extensions;
using OrderApi.Repositories.GenericRepository;
using OrderApi.Repositories.Interfaces;

namespace OrderApi.Repositories;

public class OrderRepository : GenericRepository<Order,AppDbContext>, IOrderRepository
{
    private readonly HttpContextHelper _httpContext;

    public OrderRepository(AppDbContext dbContext, HttpContextHelper httpContext) : base(dbContext)
    {
        _httpContext = httpContext;
    }

    public async Task<IEnumerable<Order>> GetUsersAsync(OrderFilter filter)
    {
        var query = DbSet.AsQueryable();

        if (filter.QuantityProduct is not null)
            query = query.Where(c => c.QuantityProduct == filter.QuantityProduct);

        if (filter.FromDate is not null)
            query = query.Where(c => c.CreatedAt > filter.FromDate);

        if (filter.ToDate is not null)
            query = query.Where(c => c.CreatedAt < filter.ToDate);

        return await query.ToPagedListAsync(_httpContext, filter);
    }
}