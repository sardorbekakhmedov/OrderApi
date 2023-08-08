using OrderApi.Models.ProductModels;

namespace OrderApi.Models.CategoryModels;

public class CategoryModel
{
    public required string CategoryName { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public virtual IEnumerable<ProductModel>? Products { get; set; }
}