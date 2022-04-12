using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.ProductAggregate;
using OnlineShop.Infrastructure.Data.Repositories;

namespace OnlineShop.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly EfContext _context;
    public UnitOfWork()
    {
        var options = new DbContextOptions<EfContext>();
        
        _context = new EfContext(options);
    }
    
    public IRepository<Product> ProductRepository => new ProductRepository(_context);
    
    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}