using ProductAPI.Domain;

namespace ProductAPI.Infrastructure.Repositories.Interfaces;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<IEnumerable<Product?>> GetByCategoryIdAsync(int categoryId);
}