using Microsoft.EntityFrameworkCore;
using OnionArchOrnegi.Application.Interfaces;
using OnionArchOrnegi.Persistence.Contexts;
using OnionArchOrnegi.SharedLibrary.Enum;
using System.Linq.Expressions;

namespace OnionArchOrnegi.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly OnionArchOrnegiDbContext _context;

    public Repository(OnionArchOrnegiDbContext context)
    {
        _context = context;
    }


    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
    {
        return await _context.Set<T>().Where(filter).AsNoTracking().ToListAsync();
    }

    public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
    {
        return orderByType == OrderByType.ASC ? await _context.Set<T>().AsNoTracking().OrderBy(selector).ToListAsync() : await _context.Set<T>().AsNoTracking().OrderByDescending(selector).ToListAsync();
    }

    public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
    {
        return orderByType == OrderByType.ASC ? await _context.Set<T>().Where(filter).AsNoTracking().OrderBy(selector).ToListAsync() : await _context.Set<T>().Where(filter).AsNoTracking().OrderByDescending(selector).ToListAsync();
    }

    public async Task<T> FindAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public T GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
    {
        return !asNoTracking ? _context.Set<T>().AsNoTracking().SingleOrDefault(filter) : _context.Set<T>().SingleOrDefault(filter);
    }

    public IQueryable<T> GetQuery()
    {
        return _context.Set<T>().AsQueryable();
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);

    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }
}