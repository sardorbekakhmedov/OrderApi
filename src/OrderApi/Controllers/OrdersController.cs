using Microsoft.AspNetCore.Mvc;
using OrderApi.Entities.PageFilters;
using OrderApi.Exceptions;
using OrderApi.Managers.Interfaces;
using OrderApi.Models.OrderModels;

namespace OrderApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderManager _orderManager;

    public OrdersController(IOrderManager orderManager)
    {
        _orderManager = orderManager;
    }

    [HttpPost]
    public async ValueTask<IActionResult> InsertOrder([FromBody] CreateOrderModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(model);

        try
        {
            return Ok(await _orderManager.CreateOrderAsync(model));
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

    [HttpGet]
    public async ValueTask<IActionResult> GetAllOrders([FromQuery] OrderFilter orderFilter)
    {
        if (!ModelState.IsValid)
            return BadRequest(orderFilter);

        try
        {
            return Ok(await _orderManager.GetOrdersAsync(orderFilter));
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpGet("{orderId:guid}")]
    public async ValueTask<IActionResult> GetByIdOrder(Guid orderId)
    {
        try
        {
            return Ok(await _orderManager.GetByIdAsync(orderId));
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

    [HttpPut("{orderId:guid}")]
    public async ValueTask<IActionResult> GetByIdOrder(Guid orderId, [FromBody] UpdateOrderModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(model);

        try
        {
            return Ok(await _orderManager.UpdateAsync(orderId, model));
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

    [HttpDelete("{orderId:guid}")]
    public async ValueTask<IActionResult> DeleteOrder(Guid orderId)
    {
        try
        {
            await _orderManager.DeleteAsync(orderId);
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