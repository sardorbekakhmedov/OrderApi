using Microsoft.EntityFrameworkCore;
using OrderApi.Context;
using OrderApi.Entities;
using OrderApi.Entities.PageFilters;
using OrderApi.Entities.PaginationEntities;
using OrderApi.Extensions;
using OrderApi.Repositories.GenericRepository;
using OrderApi.Repositories.Interfaces;

namespace OrderApi.Repositories;

public class UserRepository : GenericRepository<User,AppDbContext>, IUserRepository
{
    private readonly HttpContextHelper _httpContext;

    public UserRepository(HttpContextHelper httpContext, AppDbContext dbContext) : base(dbContext)
    {
        _httpContext = httpContext;
    }

    public async Task<IEnumerable<User>> GetUsersAsync(UserFilter filter)
    {
        var query = DbSet.AsQueryable();

        if (filter.Username is not null)
            query = query.Where(c => c.Username.Contains(filter.Username));

        if (filter.FromDate is not null)
            query = query.Where(c => c.CreatedAt > filter.FromDate);

        if (filter.ToDate is not null)
            query = query.Where(c => c.CreatedAt < filter.ToDate);

        return await query.ToPagedListAsync(_httpContext, filter);
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await DbSet.SingleOrDefaultAsync(u => u.Username == username);
    }
}