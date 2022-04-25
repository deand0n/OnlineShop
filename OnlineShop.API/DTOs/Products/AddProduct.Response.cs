using OnlineShop.Domain.AggregatesModel.ProductAggregate;

namespace OnlineShop.API.DTOs.Products;

public class AddProductResponse
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public IEnumerable<Image> Images { get; set; }

    public AddProductResponse(Product product)
    {
        Name = product.Name;
        Description = product.Description;
        Price = product.Price;
        Quantity = product.Quantity;
        Images = product.Images;
    }
}