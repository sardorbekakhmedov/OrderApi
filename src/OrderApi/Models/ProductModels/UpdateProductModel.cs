﻿namespace OrderApi.Models.ProductModels;

public class UpdateProductModel
{
    public Guid? CategoryId { get; set; }
    public string? ProductName { get; set; }
    public string? ProductDescription { get; set; }
    public decimal? UnitPrice { get; set; }
    public int? UnitInStock { get; set; }
    public bool? Discontinued { get; set; }
}