using AutoMapper;
using ProductAPI.Application.DTOs;
using ProductAPI.Application.Services.Interfaces;
using ProductAPI.Domain;
using ProductAPI.Infrastructure.Repositories.Interfaces;

namespace ProductAPI.Application.Services;

public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<ProductReadDTO>?> GetProductsAsync()
    {
        var products = await _productRepository.GetAllActiveAsync();

        if (products is null || !products.Any())
        {
            return null;
        }

        return _mapper.Map<IEnumerable<ProductReadDTO>>(products);
    }

    public async Task<ProductReadDTO?> GetProductByIdAsync(int productId)
    {
        var product = await _productRepository.GetActiveByIdAsync(productId);

        if (product is null)
        {
            return null;
        }

        return _mapper.Map<ProductReadDTO>(product);
    }

    public async Task<ProductReadDTO?> CreateProductAsync(ProductCreateUpdateDTO productDTO)
    {
        var product = _mapper.Map<Product>(productDTO);

        var createdProduct = await _productRepository.CreateAsync(product);

        return createdProduct is null
            ? throw new Exception($"Product with id {product.Id} not created")
            : _mapper.Map<ProductReadDTO>(createdProduct);
    }

    public async Task<ProductReadDTO?> UpdateProductAsync(int productId, ProductCreateUpdateDTO productDTO)
    {
        var product = await _productRepository.GetActiveByIdAsync(productId) ?? throw new ArgumentException($"Product with id {productId} not found");
        _mapper.Map(productDTO, product);

        var updatedProduct = await _productRepository.UpdateAsync(product);
        return updatedProduct is null
            ? throw new Exception($"Product with id {product.Id} not updated")
            : _mapper.Map<ProductReadDTO>(updatedProduct);
    }

    public async Task<bool> DeleteProductAsync(int productId)
    {
        var product = await _productRepository.GetActiveByIdAsync(productId) ?? throw new ArgumentException($"Product with id {productId} not found");
        await _productRepository.SoftDeleteAsync(product);

        return true;
    }
}
