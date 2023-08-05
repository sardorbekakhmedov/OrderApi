using OrderApi.Entities;
using OrderApi.Models.ProductModels;

namespace OrderApi.Extensions.EntityExtensions;

public static class ProductExtensions
{
    public static ProductModel ToProductModel(this Product product)
    {
        return new ProductModel
        {
            Id = product.Id,
            CategoryId = product.CategoryId,
            ProductName = product.ProductName,
            Description = product.Description,
            UnitPrice = product.UnitPrice,
            UnitInStock = product.UnitInStock,
        };
    }
}