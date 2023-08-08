using OrderApi.Entities;
using OrderApi.Models.CategoryModels;
using OrderApi.Models.ProductModels;

namespace OrderApi.Extensions.EntityExtensions;

public static class CategoryExtensions
{
    public static CategoryModel ToCategoryModel(this Category category)
    {
        var categoryModel = new CategoryModel
        {
            CategoryName = category.CategoryName,
            Description = category.Description,
            CreatedAt = category.CreatedAt,
            UpdateAt = category.UpdateAt
        };

        var productModels = new List<ProductModel>();

        if (category.Products is not null)
        {
            productModels.AddRange(category.Products.Select(x => x.ToProductModel()));
        }

        categoryModel.Products = productModels;

        return categoryModel;
    }
}