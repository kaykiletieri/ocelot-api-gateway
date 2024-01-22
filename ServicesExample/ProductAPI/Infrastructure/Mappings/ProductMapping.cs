using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductAPI.Domain;

namespace ProductAPI.Infrastructure.Mappings;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.CreatedAt).HasColumnName("created_at");
        builder.Property(e => e.UpdatedAt).HasColumnName("updated_at");
        builder.Property(e => e.DeletedAt).HasColumnName("deleted_at");
        builder.Property(e => e.Name).HasColumnName("name");
        builder.Property(e => e.Description).HasColumnName("description");
        builder.Property(e => e.Price).HasColumnName("price");
        builder.Property(e => e.StockQuantity).HasColumnName("stock_quantity");
    }
}