using Microsoft.EntityFrameworkCore;
using ProductAPI.Domain;
using ProductAPI.Infrastructure.Repositories.Interfaces;

namespace ProductAPI.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product?>> GetByCategoryIdAsync(int categoryId)
    {
        try
        {
            return await _dbSet.AsNoTracking().Where(x => x.CategoryId == categoryId && x.DeletedAt == null).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while getting {typeof(Product).Name} by category id.", ex);
        }
    }

    public async Task<Product?> GetByNameAsync(string name)
    {
        try
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name && x.DeletedAt == null);
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while getting {typeof(Product).Name} by name.", ex);
        }
    }
}