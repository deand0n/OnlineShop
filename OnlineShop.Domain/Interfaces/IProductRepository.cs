using System.Linq.Expressions;
using OnlineShop.Domain.AggregatesModel.ProductAggregate;
using OnlineShop.Domain.Base.Pagination;

namespace OnlineShop.Domain.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<List<Product>> PaginatedListAsync(Expression<Func<Product, bool>> expression, Pageable pageable);
}