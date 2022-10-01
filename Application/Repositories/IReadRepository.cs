using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
    IQueryable<T?> GetAll(bool tracking = true);
    IQueryable<T?> GetAllWithPaginate(int page, int pageSize, out int totalCount, out int pageCount, out bool hasPrevious, out bool hasNext, bool tracking = true);
    IQueryable<T?> GetWhere(Expression<Func<T, bool>> expression, bool tracking = true);
    Task<T?> GetByIdAsync(Guid id, bool tracking = true);
    Task<T?> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true);
}