using OrderApi.Entities.HelperEntities;

namespace OrderApi.Entities.PageFilters;

public class ProductFilter : PaginationParams
{
    public string? ProductName { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}