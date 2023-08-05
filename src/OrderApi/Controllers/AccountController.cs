using Microsoft.AspNetCore.Mvc;
using OrderApi.Exceptions;
using OrderApi.Managers.Interfaces;
using OrderApi.Models.UserModels;

namespace OrderApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IUserManager _userManager;

    public AccountController(IUserManager userManager)
    {
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromForm] CreateUserModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(model);

        try
        {
            return Ok(await _userManager.CreateUserAsync(model));
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser([FromForm] LoginUserModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(model);

        try
        {
            return Ok(await _userManager.LoginAsync(model));
        }
        catch (ObjectNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (LoginValidationException e)
        {
            return BadRequest(e.Message);
        }
        catch(Exception e) 
        {
            return Problem(e.Message);
        }
    }
}