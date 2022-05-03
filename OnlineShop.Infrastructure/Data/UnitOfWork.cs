using OnlineShop.Domain.Interfaces;
using OnlineShop.Infrastructure.Data.Repositories;

namespace OnlineShop.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly EfContext _context;
    
    public UnitOfWork(EfContext context)
    {
        _context = context;
    }
    
    public IProductRepository ProductRepository => new ProductRepository(_context);
    
    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}