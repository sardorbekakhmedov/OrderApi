namespace OrderApi.Models.OrderModels;

public class OrderModel
{
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public int QuantityProduct { get; set; }
    public decimal AmountPrice { get; set; }
}