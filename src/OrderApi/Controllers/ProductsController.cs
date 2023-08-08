using Microsoft.AspNetCore.Mvc;
using OrderApi.Entities.PageFilters;
using OrderApi.Exceptions;
using OrderApi.Managers.Interfaces;
using OrderApi.Models.ProductModels;

namespace OrderApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductManager _productManager;

    public ProductsController(IProductManager productManager)
    {
        _productManager = productManager;
    }

    [HttpPost("{categoryName:alpha}")]
    public async Task<IActionResult> InsertNewProduct(string categoryName, [FromBody] CreateProductModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(model);

        try
        {
            var newProduct = await _productManager.CreateProductAsync(categoryName, model);
            return Created("InsertNewProduct", newProduct);
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
    public async Task<IActionResult> GetAllProducts([FromQuery] ProductFilter productFilter)
    {
        if (!ModelState.IsValid)
            return BadRequest(productFilter);

        try
        {
           return Ok(await _productManager.GetProductsAsync(productFilter));
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpGet("{productId:guid}")]
    public async Task<IActionResult> GetProductById(Guid productId)
    {
        try
        {
            return Ok(await _productManager.GetByIdAsync(productId));
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

    [HttpPut("{productId:guid}")]
    public async Task<IActionResult> UpdateProduct(Guid productId, [FromBody] UpdateProductModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(model);

        try
        {
            return Accepted(await _productManager.UpdateAsync(productId, model));
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

    [HttpDelete("{productId:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid productId)
    {
        try
        {
            await _productManager.DeleteAsync(productId);
            return Accepted();
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