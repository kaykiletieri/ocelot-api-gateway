using Microsoft.EntityFrameworkCore;
using ProductAPI.Domain;
using ProductAPI.Infrastructure.Repositories.Interfaces;

namespace ProductAPI.Infrastructure.Repositories;

public class ProductRepository(ApplicationDbContext context) : BaseRepository<Product>(context), IProductRepository
{
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
}
