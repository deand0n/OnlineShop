using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.DTOs.Products;
using OnlineShop.API.Services;

namespace OnlineShop.API.Controllers;

[Route("api/[controller]")]
public class ProductsController : BaseApiController
{
    private readonly ProductsService _productsService;

    public ProductsController(ProductsService productsService)
    {
        _productsService = productsService;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
    {
        var product = await _productsService.AddProduct(request);
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetProductsList([FromQuery] GetProductsListRequest request)
    {
        var products = await _productsService.GetProductsList(request);
        return Ok(products);
    }
}