using OrderApi.Context;
using OrderApi.Entities;
using OrderApi.Entities.HelperEntities;
using OrderApi.Entities.PageFilters;
using OrderApi.Extensions;
using OrderApi.Repositories.GenericRepository;
using OrderApi.Repositories.Interfaces;

namespace OrderApi.Repositories;

public class CategoryRepository : GenericRepository<Category, AppDbContext>, ICategoryRepository
{
    private readonly HttpContextHelper _httpContext;

    public CategoryRepository(AppDbContext dbContext, HttpContextHelper httpContext) : base(dbContext)
    {
        _httpContext = httpContext;
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync(CategoryFilter filter)
    {
        IQueryable<Category> query = DbSet;

        if (filter.CategoryName is not null)
            query = query.Where(c => c.CategoryName.Contains(filter.CategoryName));

        if (filter.FromDate is not null)
            query = query.Where(c => c.CreatedAt > filter.FromDate);

        if (filter.ToDate is not null)
            query = query.Where(c => c.CreatedAt < filter.ToDate);

        return await query.ToPagedListAsync(_httpContext, filter);
    }
}