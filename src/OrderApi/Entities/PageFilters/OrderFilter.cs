using OrderApi.Entities.HelperEntities;

namespace OrderApi.Entities.PageFilters;

public class OrderFilter : PaginationParams
{
    public int? QuantityProduct { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }

}