using OnionArchOrnegi.Application.Interfaces;
using OnionArchOrnegi.Persistence.Contexts;
using OnionArchOrnegi.Persistence.Repositories;

namespace OnionArchOrnegi.Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly OnionArchOrnegiDbContext _context;

    public UnitOfWork(OnionArchOrnegiDbContext context)
    {
        _context = context;
    }
    public IRepository<T> GetRepository<T>() where T : class
    {
        return new Repository<T>(_context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
