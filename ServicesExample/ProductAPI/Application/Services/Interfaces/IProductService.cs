using ProductAPI.Application.DTOs;

namespace ProductAPI.Application.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductReadDTO>?> GetProductsAsync();
    Task<ProductReadDTO?> GetProductByIdAsync(int productId);
    Task<ProductReadDTO?> CreateProductAsync(ProductCreateUpdateDTO productDTO);
    Task<ProductReadDTO?> UpdateProductAsync(int productId, ProductCreateUpdateDTO productDTO);
    Task<bool> DeleteProductAsync(int productId);
}