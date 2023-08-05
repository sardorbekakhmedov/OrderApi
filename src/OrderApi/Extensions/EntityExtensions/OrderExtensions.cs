using OrderApi.Entities;
using OrderApi.Models.OrderModels;

namespace OrderApi.Extensions.EntityExtensions;

public static class OrderExtensions
{
    public static OrderModel ToOrderModel(this Order order)
    {
        return new OrderModel
        {
            Id = order.Id,
            ProductId = order.ProductId,
            UserId = order.UserId,
            QuantityProduct = order.QuantityProduct,
            AmountPrice = order.AmountPrice,
        };
    }
}