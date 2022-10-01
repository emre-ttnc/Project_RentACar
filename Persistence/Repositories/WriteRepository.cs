using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
    readonly RentACarDbContext _context;

    public WriteRepository(RentACarDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task<bool> AddAsync(T entity)
    {
        EntityEntry<T> entityEntry = await Table.AddAsync(entity);
        return entityEntry.State == EntityState.Added;
    }

    public async Task<bool> AddRangeAsync(List<T> entities)
    {
        await Table.AddRangeAsync(entities);
        return true;
    }

    public bool Remove(T entity)
    {
        EntityEntry<T> entityEntry = Table.Remove(entity);
        return entityEntry.State == EntityState.Deleted;
    }

    public async Task<bool> RemoveByIdAsync(Guid id)
    {
        T? entry = await Table.FirstOrDefaultAsync(entry => entry.Id == id);
        if (entry != null)
            return Remove(entry);
        else
            return false;
    }

    public bool RemoveRange(List<T> entities)
    {
        Table.RemoveRange(entities);
        return true;
    }

    public bool Update(T entity)
    {
        EntityEntry<T> entityEntry = Table.Update(entity);
        return entityEntry.State == EntityState.Modified;
    }

    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
}