using OrderApi.Context;
using OrderApi.Entities;
using OrderApi.Entities.PageFilters;
using OrderApi.Entities.PaginationEntities;
using OrderApi.Extensions;
using OrderApi.Repositories.GenericRepository;
using OrderApi.Repositories.Interfaces;

namespace OrderApi.Repositories;

public class ProductRepository : GenericRepository<Product,AppDbContext>, IProductRepository
{
    private readonly HttpContextHelper _httpContext;

    public ProductRepository(AppDbContext dbContext, HttpContextHelper httpContext) : base(dbContext)
    {
        _httpContext = httpContext;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync(ProductFilter filter)
    {
        var query = DbSet.AsQueryable();

        if (filter.ProductName is not null)
            query = query.Where(c => c.ProductName.Contains(filter.ProductName));

        if (filter.FromDate is not null)
            query = query.Where(c => c.CreatedAt > filter.FromDate);

        if (filter.ToDate is not null)
            query = query.Where(c => c.CreatedAt < filter.ToDate);

        return await query.ToPagedListAsync(_httpContext, filter);
    }
}