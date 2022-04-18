using OnlineShop.Domain.AggregatesModel.ProductAggregate;

namespace OnlineShop.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Product> ProductRepository { get; }
    Task<bool> SaveChangesAsync();
}