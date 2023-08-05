namespace OrderApi.Models.UserModels;

public class UpdateUserModel
{
    public string? Username { get; set; }
    public string? PhoneNumber { get; set; }
    public IFormFile? Image { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}