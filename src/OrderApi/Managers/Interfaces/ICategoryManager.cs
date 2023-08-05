﻿using OrderApi.Entities;
using OrderApi.Models.CategoryModels;

namespace OrderApi.Managers.Interfaces;

public interface ICategoryManager
{
    public Task<Category> CreateUserAsync(CreateCategoryModel model);
    public IEnumerable<Category> GetUsersAsync();
    public Task<Category> GetByIdAsync(Guid categoryId);
    public Task<Category> UpdateAsync(Guid categoryId);
    public Task DeleteAsync(Guid categoryId);
}