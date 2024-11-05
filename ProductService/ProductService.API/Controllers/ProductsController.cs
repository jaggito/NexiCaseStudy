using Microsoft.AspNetCore.Mvc;
using ProductService.Core.Entities;
using ProductService.Core.Interfaces;

namespace ProductService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> Get()
    {
        var products = await _productService.GetProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> Get(Guid id)
    {
        var product = await _productService.GetProductAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    // Other endpoints
}
