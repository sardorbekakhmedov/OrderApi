namespace OrderApi.Entities;

public class Category : BaseEntity
{
    public required string CategoryName { get; set; }
    public string? Description { get; set; }
    public virtual IEnumerable<Product>? Products { get; set; }
}