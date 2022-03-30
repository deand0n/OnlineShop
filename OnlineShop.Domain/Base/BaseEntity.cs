namespace OnlineShop.Domain.Base;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    // public DateTime CreateDate { get; } = DateTime.UtcNow;
}