using OnlineShop.Domain.Attributes;
using OnlineShop.Domain.Base;

namespace OnlineShop.Domain.ProductAggregate;

[AggregateRoot]
public class Product : BaseEntity 
{
    public string Name { get; set; }
}