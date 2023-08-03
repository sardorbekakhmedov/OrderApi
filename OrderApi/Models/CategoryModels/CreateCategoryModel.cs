namespace OrderApi.Models.CategoryModels;

public class CreateCategoryModel
{
    public required string CategoryName { get; set; }
    public string? Description { get; set; }
}