using Microsoft.EntityFrameworkCore;
using ProductAPI.Domain;
using ProductAPI.Infrastructure.Mappings;

namespace ProductAPI.Infrastructure;

public class ApplicationDbContext: DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductMapping());

        base.OnModelCreating(modelBuilder);
    }
}