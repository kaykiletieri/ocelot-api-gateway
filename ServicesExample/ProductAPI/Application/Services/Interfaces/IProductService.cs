using ProductAPI.Application.DTOs;

namespace ProductAPI.Application.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductReadDTO>> GetProductsAsync();
    Task<ProductReadDTO> GetProductByIdAsync(int productId);
    Task<int> CreateProductAsync(ProductCreateUpdateDTO productDTO);
    Task UpdateProductAsync(int productId, ProductCreateUpdateDTO productDTO);
    Task DeleteProductAsync(int productId);

    Task<IEnumerable<ProductReadDTO>> GetProductsInStockAsync();
    Task UpdateStockQuantityAsync(int productId, int newQuantity);
    Task<IEnumerable<ProductReadDTO>> SearchProductsAsync(string searchTerm);
}
