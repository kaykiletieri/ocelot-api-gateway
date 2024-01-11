using ProductAPI.Domain;

namespace ProductAPI.Infrastructure.Repositories.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T?>> GetAllAsync();
    Task<IEnumerable<T?>> GetAllActiveAsync();
    Task<T?> GetByIdAsync(long id);
    Task<T?> GetActiveByIdAsync(long id);
    Task<T?> CreateAsync(T entity);
    Task<T?> UpdateAsync(T entity);
    Task<T?> DeleteAsync(T entity);
    Task<T?> DeleteAsync(long id);
    Task<T?> SoftDeleteAsync(T entity);
    Task<T?> SoftDeleteAsync(long id);
}
