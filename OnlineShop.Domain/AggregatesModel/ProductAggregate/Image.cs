using OnlineShop.Domain.Base;

namespace OnlineShop.Domain.AggregatesModel.ProductAggregate;

public class Image : IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime? DeleteDate { get; set; }
    public bool IsDeleted { get; set; }
    
    public string Url { get; set; }
    public string Alt { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}