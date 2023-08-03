namespace OrderApi.Models.OrderModels;

public class CreateOrderModel
{
    public required Guid ProductId { get; set; }
    public required Guid UserId { get; set; }
    public int QuantityProduct { get; set; }
    public decimal AmountPrice { get; set; }
}