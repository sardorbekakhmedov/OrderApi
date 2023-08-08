using OrderApi.Models.OrderModels;

namespace OrderApi.Models.UserModels;

public class UserModel
{
    public Guid Id { get; set; }
    public required string Username { get; set; }
    public required string PhoneNumber { get; set; }
    public string? ImageUrl { get; set; }
    public string? Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }

    public virtual IEnumerable<OrderModel>? Orders { get; set; }
}