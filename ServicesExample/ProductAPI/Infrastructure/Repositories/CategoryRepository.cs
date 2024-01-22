using ProductAPI.Domain;
using ProductAPI.Infrastructure.Repositories.Interfaces;

namespace ProductAPI.Infrastructure.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}