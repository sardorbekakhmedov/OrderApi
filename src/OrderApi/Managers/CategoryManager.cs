using OrderApi.Entities;
using OrderApi.Entities.PageFilters;
using OrderApi.Exceptions;
using OrderApi.Extensions.EntityExtensions;
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

    public async Task<CategoryModel> CreateCategoryAsync(CreateCategoryModel model)
    {
        var category = new Category()
        {
            CategoryName = model.CategoryName,
            Description = model.Description,
        };

        var newCategory = await _categoryRepository.AddAsync(category);
        return newCategory.ToCategoryModel();
    }

    public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync(CategoryFilter categoryFilter)
    {
        var categories = await _categoryRepository.GetCategoriesAsync(categoryFilter);
        return categories.Select(p => p.ToCategoryModel());
    }

    public async Task<CategoryModel> GetByIdAsync(Guid categoryId)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId)
                      ?? throw new ObjectNotFoundException(nameof(Product));

        return category.ToCategoryModel();
    }

    public async Task<CategoryModel> UpdateAsync(Guid categoryId, UpdateCategoryModel model)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId)
                       ?? throw new ObjectNotFoundException(nameof(Product));

        category.CategoryName = model.CategoryName ?? category.CategoryName;
        category.Description = model.Description ?? category.Description;

        var updatedCategory = await _categoryRepository.UpdateAsync(category);

        return updatedCategory.ToCategoryModel();
    }

    public async Task DeleteAsync(Guid categoryId)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId)
                       ?? throw new ObjectNotFoundException(nameof(Product));

        await _categoryRepository.RemoveAsync(category);
    }
}