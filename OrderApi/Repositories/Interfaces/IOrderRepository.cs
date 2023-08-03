﻿using OrderApi.Entities;
using OrderApi.Models.OrderModels;

namespace OrderApi.Repositories.Interfaces;

public interface IOrderRepository
{
    public Task<Order> CreateUserAsync(CreateOrderModel model);
    public IEnumerable<Order> GetUsersAsync();
    public Task<Order> GetByIdAsync(Guid orderId);
    public Task<Order> UpdateAsync(Guid orderId);
    public Task DeleteAsync(Guid orderId);
}