using OrderApi.Entities.PaginationEntities;

namespace OrderApi.Entities.PageFilters;

public class CategoryFilter : PaginationParams
{
    public string? CategoryName { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}