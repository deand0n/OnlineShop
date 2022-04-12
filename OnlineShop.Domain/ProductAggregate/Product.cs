using System.ComponentModel.DataAnnotations;
using OnlineShop.Domain.Attributes;
using OnlineShop.Domain.Base;

namespace OnlineShop.Domain.ProductAggregate;

[AggregateRoot]
public class Product : BaseEntity 
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; }
}