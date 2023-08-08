namespace OrderApi.Models.OrderModels;

public class OrderModel
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public int QuantityProduct { get; set; }
    public decimal AmountPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }
}