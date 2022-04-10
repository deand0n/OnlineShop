using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnlineShop.Domain.Base;
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