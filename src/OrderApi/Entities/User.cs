namespace OrderApi.Entities;

public class User : BaseEntity
{
    public required string Username { get; set; }
    public required string PhoneNumber { get; set; }
    public string? ImageUrl { get; set; }
    public string? Email { get; set; }
    public string PasswordHash { get; set; } = null!;

    public virtual IEnumerable<Order>? Orders { get; set; }
}