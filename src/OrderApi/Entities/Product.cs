namespace OrderApi.Entities;

public class Product : BaseEntity
{
    public Guid CategoryId { get; set; }
    public virtual Category? Category { get; set; }

    public required string ProductName { get; set; }
    public string? Description { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitInStock { get; set; }
    public bool Discontinued { get; set; }
}