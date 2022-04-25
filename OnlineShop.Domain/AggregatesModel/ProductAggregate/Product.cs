using OnlineShop.Domain.Attributes;

namespace OnlineShop.Domain.AggregatesModel.ProductAggregate;

[AggregateRoot]
public class Product
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public IEnumerable<Image> Images { get; private set; }
    
    // copy and paste to every entity
    // BEGIN
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime DeleteDate { get; set; }
    public bool IsDeleted { get; set; }
    // END

    protected Product()
    {
        
    }

    // might want to use builder pattern here
    // https://refactoring.guru/design-patterns/builder
    public static Product Create(string name, string description, decimal price, int quantity, IEnumerable<Image>? images)
    {
        Product p = new();
        
        p.AddName(name);
        p.AddDescription(description);
        p.AddPrice(price);
        p.AddQuantity(quantity);
        p.AddImages(images);
        
        return p;
    }
    
    public string AddName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name is required");
        }

        Name = name.Trim();
        
        return Name;
    }
    
    public string AddDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Description is required");
        }

        Description = description.Trim();
        
        return Description;
    }
    
    public decimal AddPrice(decimal price)
    {
        if (price <= 0)
        {
            throw new ArgumentException("Price must be greater than 0");
        }

        Price = price;
        
        return Price;
    }
    
    public int AddQuantity(int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("Quantity must be greater than 0");
        }

        Quantity = quantity;
        
        return Quantity;
    }
    
    public IEnumerable<Image> AddImages(IEnumerable<Image> images)
    {
        if (images == null)
        {
            throw new ArgumentException("Images is required");
        }

        Images = images;
        
        return Images;
    }
}