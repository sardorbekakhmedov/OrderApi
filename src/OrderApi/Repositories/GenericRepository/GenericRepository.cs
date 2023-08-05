using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace OrderApi.Repositories.GenericRepository;

public class GenericRepository<TEntity, TDbContext> : IGenericRepository<TEntity>
    where TEntity : class where TDbContext : DbContext
{
    private readonly DbContext _dbContext;
    protected DbSet<TEntity> DbSet;

    public GenericRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
        DbSet = _dbContext.Set<TEntity>();
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
        => await DbSet.FindAsync(id);

    public IQueryable<TEntity> GetAll()
        => DbSet;

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        => DbSet.Where(expression);

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var entry = await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var entry = DbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public async Task RemoveAsync(TEntity entity)
    {
        DbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}

