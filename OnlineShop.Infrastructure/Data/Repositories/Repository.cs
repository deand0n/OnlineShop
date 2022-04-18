using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Base;
using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Infrastructure.Data.Repositories;

public abstract class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _dbSet;
    
    protected Repository(DbContext context)
    {
        _dbSet = context.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return Task.FromResult(entity);
    }

    public Task<bool> DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        return Task.FromResult(true);
    }

    public Task<T?> GetByIdAsync(Guid id)
    {
        return _dbSet.FirstOrDefaultAsync(entity => entity.Id == id);
    }

    public Task<List<T>> ListAsync(Expression<Func<T, bool>> expression)
    {
        return _dbSet.Where(expression).ToListAsync();
    }
    
    public Task<int> CountAsync(Expression<Func<T, bool>> expression)
    {
        return _dbSet.CountAsync();
    }
}