using OnlineShop.Domain.AggregatesModel.ProductAggregate;

namespace OnlineShop.API.DTOs.Products;


public class GetProductsListResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public IEnumerable<Image> Images { get; set; }
}