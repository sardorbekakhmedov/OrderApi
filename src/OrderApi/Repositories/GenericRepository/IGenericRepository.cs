using System.Linq.Expressions;

namespace OrderApi.Repositories.GenericRepository;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(Guid id);
    IQueryable<TEntity> GetAll();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task RemoveAsync(TEntity entity);
    Task SaveChangesAsync();
}

public interface IGenericRepositoryRange<TEntity> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(int id);
    Task AddRange(IEnumerable<TEntity> entity);
    Task UpdateRange(IEnumerable<TEntity> entity);
    Task RemoveRange(IEnumerable<TEntity> entity);
}