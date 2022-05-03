using OnlineShop.Domain.AggregatesModel.ProductAggregate;

namespace OnlineShop.API.DTOs.Products;

public class UpdateProductResponse
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public IEnumerable<Image> Images { get; private set; }
}