using OnlineShop.Domain.Attributes;
using OnlineShop.Domain.Base;

namespace OnlineShop.Domain.AggregatesModel.ProductAggregate;

[AggregateRoot]
public class Product : BaseEntity 
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
    
    
}