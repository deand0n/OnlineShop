using OnlineShop.Domain.Base;

namespace OnlineShop.Domain.AggregatesModel.ProductAggregate;

public class Image : BaseEntity
{
    public string Url { get; set; }
    public string Alt { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    
    // copy and paste to every entity
    // BEGIN
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime DeleteDate { get; set; }
    public bool IsDeleted { get; set; }
    // END
}