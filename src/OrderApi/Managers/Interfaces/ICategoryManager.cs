using OrderApi.Entities.PageFilters;
using OrderApi.Models.CategoryModels;

namespace OrderApi.Managers.Interfaces;

public interface ICategoryManager
{
    public Task<CategoryModel> CreateCategoryAsync(CreateCategoryModel model);
    public Task<IEnumerable<CategoryModel>> GetCategoriesAsync(CategoryFilter categoryFilter);
    public Task<CategoryModel> GetByIdAsync(Guid categoryId);
    public Task<CategoryModel> UpdateAsync(Guid categoryId, UpdateCategoryModel model);
    public Task DeleteAsync(Guid categoryId);
}