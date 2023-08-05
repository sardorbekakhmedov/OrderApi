using OrderApi.Entities;
using OrderApi.Models.CategoryModels;

namespace OrderApi.Managers.Interfaces;

public interface ICategoryManager
{
    public Task<Category> CreateCategoryAsync(CreateCategoryModel model);
    public IEnumerable<Category> GetCategoriesAsync();
    public Task<Category> GetByIdAsync(Guid categoryId);
    public Task<Category> UpdateAsync(Guid categoryId, UpdateCategoryModel model);
    public Task DeleteAsync(Guid categoryId);
}