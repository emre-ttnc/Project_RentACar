using Domain.Entities;

namespace Application.Repositories;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
{
    Task<bool> AddAsync(T entity);
    Task<bool> AddRangeAsync(List<T> entities);
    bool Update(T entity);
    bool Remove(T entity);
    Task<bool> RemoveByIdAsync(Guid id);
    bool RemoveRange(List<T> entities);
    Task<int> SaveAsync();

}