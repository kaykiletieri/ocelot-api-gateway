using ProductAPI.Application.DTOs;
using ProductAPI.Application.Services.Interfaces;

namespace ProductAPI.Application.Services;

public class ProductService : IProductService
{
    Task<IEnumerable<ProductReadDTO>> GetProductsAsync()
    {
        try
        {

        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while getting all products", ex);
        }
    }
}
