using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Contexts;

namespace WebApp.Repositories;

public abstract class ProductRepo<TEntity> where TEntity : class
{
    private readonly DataContext _context;
    public ProductRepo(DataContext context)
    {
        _context = context;
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        return entity!;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var entities = await _context.Set<TEntity>().ToListAsync();
        return entities;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<bool> DeleteAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch { }

        return false;
    }
}
