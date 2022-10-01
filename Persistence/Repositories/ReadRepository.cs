﻿using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{

    private readonly RentACarDbContext _context;

    public ReadRepository(RentACarDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T?> GetAll(int page, int pageSize, out int totalCount, out int pageCount, out bool hasPrevious, out bool hasNext, bool tracking = true)
    {
        totalCount = Table.Count();
        pageCount = totalCount > pageSize ? totalCount / pageSize + 1 : 1;
        hasPrevious = page > 1;
        hasNext = page * pageSize < totalCount;
        return tracking ? Table.AsQueryable().Skip((page-1) * pageSize).Take(pageSize) : Table.AsNoTracking().AsQueryable().Skip((page-1) * pageSize).Take(pageSize);
    }

    public async Task<T?> GetByIdAsync(Guid id, bool tracking = true) =>
        tracking ? await Table.FindAsync(id) : await Table.AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id);

    public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true) =>
        tracking ? await Table.FirstOrDefaultAsync(expression) : await Table.AsNoTracking().FirstOrDefaultAsync(expression);

    public IQueryable<T?> GetWhere(Expression<Func<T, bool>> expression, bool tracking = true) =>
        tracking ? Table.Where(expression) : Table.AsNoTracking().Where(expression);
}