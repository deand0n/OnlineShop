using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.AggregatesModel.ProductAggregate;
using OnlineShop.Domain.Base.Pagination;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Infrastructure.Data.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(DbContext context) : base(context)
    {
    }
    
    public Task<List<Product>> PaginatedListAsync(Expression<Func<Product, bool>> expression, Pageable pageable)
    {
        var skipPages = pageable.CurrentPage * pageable.PageSize;
        
        return DbSet.Where(expression).Skip(skipPages).ToListAsync();
        // return DbSet.Where(expression).Skip(skipPages).Take(pageable.PageSize).ToListAsync();
    }
}