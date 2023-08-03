using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderApi.Context;
using OrderApi.Entities;
using OrderApi.Models.UserModels;

namespace OrderApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly OrderApiDbContext _dbContext;

    public UsersController(OrderApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromForm] CreateUserModel model)
    {
        var user = new User()
        {
            Username = model.Username,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false,
        };

        user.PasswordHash = new PasswordHasher<User>().HashPassword(user, model.Password);

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(await _dbContext.Users.ToListAsync());
    }
}