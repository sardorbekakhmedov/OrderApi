﻿using Microsoft.AspNetCore.Mvc;
using OrderApi.Entities.PageFilters;
using OrderApi.Exceptions;
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
    public async ValueTask<IActionResult> InsertNewCategory([FromBody] CreateCategoryModel model)
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
    public async ValueTask<IActionResult> GetAllCategories([FromQuery] CategoryFilter categoryFilter)
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

    [HttpGet("{categoryId:guid}")]
    public async ValueTask<IActionResult> GetCategoryById(Guid categoryId)
    {
        try
        {
            return Ok(await _categoryManager.GetByIdAsync(categoryId));
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

    [HttpPost("{categoryId:guid}")]
    public async ValueTask<IActionResult> UpdateCategory(Guid categoryId, UpdateCategoryModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(model);

        try
        {
            return Ok(await _categoryManager.UpdateAsync(categoryId, model));
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

    [HttpDelete("{categoryId:guid}")]
    public async ValueTask<IActionResult> DeleteCategory(Guid categoryId)
    {
        try
        {
            return Ok(await _categoryManager.GetByIdAsync(categoryId));
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