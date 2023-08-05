using System.ComponentModel.DataAnnotations;

namespace OrderApi.Models.UserModels;

public class CreateUserModel
{
    public required string Username { get; set; }
    public required string PhoneNumber { get; set; }
    public IFormFile? Image { get; set; }
    public string? Email { get; set; }
    public required string Password { get; set; }
    [Compare(nameof(Password))]
    public required string ConfirmPassword { get; set; }
}