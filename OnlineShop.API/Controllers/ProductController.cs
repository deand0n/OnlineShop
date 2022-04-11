using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.DTOs.Products;
using OnlineShop.API.Services;

namespace OnlineShop.API.Controllers;

public class ProductController : BaseApiController
{
    private readonly ProductService _productService;

    ProductController(ProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProductsList([FromQuery] GetProductsListRequest request)
    {
        var products = await _productService.GetProductsList(request);
        return Ok(products);
    }
}