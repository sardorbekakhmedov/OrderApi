using OrderApi.Entities;
using OrderApi.Entities.PageFilters;
using OrderApi.Exceptions;
using OrderApi.Extensions.EntityExtensions;
using OrderApi.Managers.Interfaces;
using OrderApi.Models.OrderModels;
using OrderApi.Repositories.Interfaces;

namespace OrderApi.Managers;

public class OrderManager : IOrderManager
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserManager _userManager;
    private readonly IProductManager _productManager;

    public OrderManager(IOrderRepository orderRepository, IUserManager userManager, IProductManager productManager)
    {
        _orderRepository = orderRepository;
        _userManager = userManager;
        _productManager = productManager;
    }

    public async Task<OrderModel> CreateOrderAsync(CreateOrderModel model)
    {
        var user = await _userManager.GetByIdAsync(model.UserId);
        var product = await _productManager.GetByIdAsync(model.ProductId);

        var order = new Order
        {
            UserId = user.Id,
            ProductId = product.Id,
            QuantityProduct = model.QuantityProduct,
            AmountPrice = model.AmountPrice
        };

        var newOrder = await _orderRepository.AddAsync(order);
        return newOrder.ToOrderModel();
    }

    public async Task<IEnumerable<OrderModel>> GetOrdersAsync(OrderFilter orderFilter)
    {
        var orders = await _orderRepository.GetUsersAsync(orderFilter);
        return orders.Select(o => o.ToOrderModel());
    }

    public async Task<OrderModel> GetByIdAsync(Guid orderId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId) 
            ?? throw new ObjectNotFoundException(nameof(Order));

        return order.ToOrderModel();
    }

    public async Task<OrderModel> UpdateAsync(Guid orderId, UpdateOrderModel model)
    {
        var order = await _orderRepository.GetByIdAsync(orderId)
                    ?? throw new ObjectNotFoundException(nameof(Order));

        order.UserId = model.UserId ?? order.UserId;
        order.ProductId = model.ProductId ?? order.ProductId;
        order.QuantityProduct = model.QuantityProduct ?? order.QuantityProduct;
        order.AmountPrice = model.AmountPrice ?? order.AmountPrice;
        
        var newOrder = await _orderRepository.UpdateAsync(order);
        return newOrder.ToOrderModel();
    }

    public async Task DeleteAsync(Guid orderId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId)
                    ?? throw new ObjectNotFoundException(nameof(Order));

        await _orderRepository.RemoveAsync(order);
    }
}