using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Entities.PageFilters;
using OrderApi.Exceptions;
using OrderApi.Managers.Interfaces;
using OrderApi.Models.UserModels;

namespace OrderApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserManager _userManager;

    public UsersController(IUserManager userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers([FromQuery] UserFilter filter)
    {
        if (!ModelState.IsValid)
            return BadRequest(filter);

        try
        {
            return Ok(await _userManager.GetUsersAsync(filter));
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetUsersById(Guid userId)
    {
        try
        {
            return Ok(await _userManager.GetByIdAsync(userId));
        }
        catch (ObjectNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpPut("{userId:guid}")]
    [Authorize]
    public async Task<IActionResult> UpdateUser(Guid userId, [FromForm] UpdateUserModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(model);
        
        try
        {
            return Ok(await _userManager.UpdateAsync(userId, model));
        }
        catch (ObjectNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpDelete("{userId:guid}")]
    [Authorize]
    public async Task<IActionResult> DeleteUser(Guid userId)
    {
        try
        {
            await _userManager.DeleteAsync(userId);
            return Ok();
        }
        catch (ObjectNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
}