namespace OnlineShop.Domain.Base;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime DeleteDate { get; set; }
    public bool IsDeleted { get; set; }
}