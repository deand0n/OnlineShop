using OnlineShop.Domain.Attributes;
using OnlineShop.Domain.Base;

namespace OnlineShop.Domain.AggregatesModel.ProductAggregate;

[AggregateRoot]
public class Product : IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime? DeleteDate { get; set; }
    public bool IsDeleted { get; set; }
    
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public IEnumerable<Image> Images { get; private set; }
    

    protected Product()
    {
        
    }

    // might want to use builder pattern here
    // https://refactoring.guru/design-patterns/builder
    public static Product Create(string name, string description, decimal price, int quantity, IEnumerable<Image>? images)
    {
        Product product = new();

        if (product.TryUpdateName(name)
            && product.TryUpdateDescription(description)
            && product.TryUpdatePrice(price)
            && product.TryUpdateQuantity(quantity)
            && product.TryUpdateImages(images))
        {
            return product;
        }
        
        throw new InvalidOperationException("Product could not be created.");
    }
    
    public Product Update(Product product, string? name, string? description, decimal? price, int? quantity, IEnumerable<Image>? images)
    { 
        product.TryUpdateName(name);
        product.TryUpdateDescription(description); 
        product.TryUpdatePrice(price); 
        product.TryUpdateQuantity(quantity);
        product.TryUpdateImages(images);
        
        return product;
    }
    
    public bool TryUpdateName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return false;
        }

        Name = name.Trim();
        
        return true;
    }
    
    public bool TryUpdateDescription(string? description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            return false;
        }

        Description = description.Trim();
        
        return true;
    }
    
    public bool TryUpdatePrice(decimal? price)
    {
        if (price is null || price < 0)
        {
            return false;
        }

        Price = price.Value;
        
        return true;
    }
    
    public bool TryUpdateQuantity(int? quantity)
    {
        if (quantity is null || quantity < 0)
        {
            return false;
        }

        Quantity = quantity.Value;
        
        return true;
    }
    
    public bool TryUpdateImages(IEnumerable<Image>? images)
    {
        if (images == null)
        {
            return false;
        }

        Images = images;
        
        return true;
    }
}