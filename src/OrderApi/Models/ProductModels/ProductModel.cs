namespace OrderApi.Models.ProductModels;

public class ProductModel
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public required string ProductName { get; set; }
    public string? Description { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitInStock { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }
}