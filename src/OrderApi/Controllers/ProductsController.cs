using Microsoft.AspNetCore.Mvc;
using OrderApi.Repositories.Interfaces;

namespace OrderApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpPost]
    public IActionResult CreateProduct()
    {
        return Ok();
    }
}