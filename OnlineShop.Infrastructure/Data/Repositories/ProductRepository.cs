using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.ProductAggregate;

namespace OnlineShop.Infrastructure.Data.Repositories;

public class ProductRepository : Repository<Product>
{
    public ProductRepository(DbContext context) : base(context)
    {
        
    }
}