using OrderApi.Entities;
using OrderApi.Models.OrderModels;
using OrderApi.Models.UserModels;

namespace OrderApi.Extensions.EntityExtensions;

public static class UserExtensions
{
    public static UserModel ToUserModel(this User user)
    {
        var userModel = new UserModel
        {
            Id = user.Id,
            Username = user.Username,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email,
            ImageUrl = user.ImageUrl,
            CreatedAt = user.CreatedAt,
            UpdateAt = user.UpdateAt
        };

        var orderModels = new List<OrderModel>();

        if (user.Orders is not null)
        {
            orderModels.AddRange(user.Orders.Select(order => order.ToOrderModel()));
        }

        userModel.Orders = orderModels;

        return userModel;
    }
}