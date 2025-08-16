using OnionArchOrnegi.SharedLibrary.Enum;
using System.Linq.Expressions;

namespace OnionArchOrnegi.Application.Interfaces;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);

    Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC);

    Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC);

    Task<T> FindAsync(int id);

    T GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false);

    IQueryable<T> GetQuery();
    void Remove(T entity);

    Task AddAsync(T entity);

    Task UpdateAsync(T entity);
}
