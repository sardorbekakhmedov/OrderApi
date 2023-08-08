namespace OrderApi.Entities;

public class Order : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public int QuantityProduct { get; set; }
    public decimal AmountPrice { get; set; }
}