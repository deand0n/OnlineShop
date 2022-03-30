using System.Linq.Expressions;
using OnlineShop.Domain.Base;

namespace OnlineShop.Domain.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<T> AddAsync(T entity);

    Task<T> UpdateAsync(T entity);

    Task<bool> DeleteAsync(T entity);

    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);

    Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate);
}