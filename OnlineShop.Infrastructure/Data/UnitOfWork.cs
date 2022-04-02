using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.ProductAggregate;
using OnlineShop.Infrastructure.Data.Repositories;

namespace OnlineShop.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly EFContext _context;
    public UnitOfWork(EFContext context)
    {
        _context = context;
    }
    
    private IRepository<Product>? _productRepository;

    public IRepository<Product> ProductRepository => _productRepository ?? new ProductRepository(_context);


    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}