using OnlineShop.Domain.AggregatesModel.ProductAggregate;

namespace OnlineShop.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IProductRepository ProductRepository { get; }
    Task<bool> SaveChangesAsync();
}