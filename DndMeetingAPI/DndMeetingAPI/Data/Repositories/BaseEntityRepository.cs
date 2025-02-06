namespace DndMeetingAPI.Data.Repositories;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Models;

public class BaseEntityRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseEntityRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public Task<List<TEntity>> GetAllAsync(CancellationToken ct = default)
        => _dbSet.ToListAsync(ct);

    public IQueryable<TEntity> GetAllQueryable()
        => _dbSet.AsQueryable();

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken ct = default)
    {
        await _dbSet.AddAsync(entity, ct);
        await _context.SaveChangesAsync(ct);
        return entity;
    }

    public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken ct = default)
    {
        await _dbSet.AddRangeAsync(entities, ct);
        await _context.SaveChangesAsync(ct);
        return entities;
    }

    public Task<List<TEntity>> GetEntitiesByIdsAsync(IEnumerable<Guid> ids, CancellationToken ct = default)
    {
        return _dbSet.Where(entity => ids.Contains(entity.Id)).ToListAsync(ct);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken ct = default)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken ct = default)
    {
        _dbSet.UpdateRange(entities);
        await _context.SaveChangesAsync(ct);
    }
}
