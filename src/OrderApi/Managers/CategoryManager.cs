using OrderApi.Entities;
using OrderApi.Managers.Interfaces;
using OrderApi.Models.CategoryModels;
using OrderApi.Repositories.Interfaces;

namespace OrderApi.Managers;

public class CategoryManager : ICategoryManager
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryManager(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public Task<Category> CreateCategoryAsync(CreateCategoryModel model)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Category> GetCategoriesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetByIdAsync(Guid categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<Category> UpdateAsync(Guid categoryId, UpdateCategoryModel model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid categoryId)
    {
        throw new NotImplementedException();
    }
}