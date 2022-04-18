using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.AggregatesModel.ProductAggregate;

namespace OnlineShop.Infrastructure.Data.Repositories;

public class ProductRepository : Repository<Product>
{
    public ProductRepository(DbContext context) : base(context)
    {
        
    }
}