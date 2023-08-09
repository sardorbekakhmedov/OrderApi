using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OrderApi.Entities.PaginationEntities;

namespace OrderApi.Extensions;

public static class QueryableExtensions
{
    public static async Task<IEnumerable<TEntity>> ToPagedListAsync<TEntity>(this IQueryable<TEntity> source,
        HttpContextHelper httpContext, PaginationParams paginationParams)
    {
        httpContext.AddResponseHeader("X-Pagination", JsonConvert.SerializeObject(
            new PaginationMetaData(
                source.Count(), 
                paginationParams.PageSize,
                paginationParams.CurrentPage)));

        return await source.Skip(paginationParams.PageSize * (paginationParams.CurrentPage - 1))
            .Take(paginationParams.PageSize).ToListAsync();
    }
}