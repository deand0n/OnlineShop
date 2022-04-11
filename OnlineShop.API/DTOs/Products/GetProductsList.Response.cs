using OnlineShop.Domain.Base;
using OnlineShop.Domain.ProductAggregate;

namespace OnlineShop.API.DTOs.Products;


public class GetProductsListResponse : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; }
}