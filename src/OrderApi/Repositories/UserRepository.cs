using Microsoft.EntityFrameworkCore;
using OrderApi.Context;
using OrderApi.Entities;
using OrderApi.Entities.HelperEntities;
using OrderApi.Entities.PageFilters;
using OrderApi.Extensions;
using OrderApi.Repositories.GenericRepository;
using OrderApi.Repositories.Interfaces;

namespace OrderApi.Repositories;

public class UserRepository : GenericRepository<User,AppDbContext>, IUserRepository
{
    private readonly HttpContextHelper _httpContext;
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext, HttpContextHelper httpContext) : base(dbContext)
    {
        _httpContext = httpContext;
        _dbContext = dbContext;
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
        return await _dbContext.Users.SingleOrDefaultAsync(u => u.Username == username);
    }
}