using Microsoft.AspNetCore.Mvc;
using OrderApi.Entities.PageFilters;
using OrderApi.Managers.Interfaces;
using OrderApi.Models.CategoryModels;

namespace OrderApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryManager _categoryManager;

    public CategoriesController(ICategoryManager categoryManager)
    {
        _categoryManager = categoryManager;
    }

    [HttpPost]
    public async Task<IActionResult> InsertNewCategory([FromBody] CreateCategoryModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(model);

        try
        {
            var newProduct = await _categoryManager.CreateCategoryAsync(model);
            return Created("InsertNewCategory", newProduct);
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories([FromQuery] CategoryFilter categoryFilter)
    {
        if (!ModelState.IsValid)
            return BadRequest(categoryFilter);

        try
        {
            return Ok(await _categoryManager.GetCategoriesAsync(categoryFilter));
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
}