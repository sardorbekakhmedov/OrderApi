using OrderApi.Entities.PaginationEntities;

namespace OrderApi.Entities.PageFilters;

public class UserFilter : PaginationParams
{
    public string? Username { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}