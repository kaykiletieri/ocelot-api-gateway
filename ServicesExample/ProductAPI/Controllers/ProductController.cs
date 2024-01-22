using Microsoft.AspNetCore.Mvc;
using ProductAPI.Application.DTOs;
using ProductAPI.Application.Services.Interfaces;

namespace ProductAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductReadDTO>?>> GetProductsAsync()
    {
        try
        {
            var products = await _productService.GetProductsAsync();

            if (products is null)
            {
                return NotFound();
            }

            return Ok(products);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{productId:int}")]
    public async Task<ActionResult<ProductReadDTO?>> GetProductByIdAsync(int productId)
    {
        try
        {
            var product = await _productService.GetProductByIdAsync(productId);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<ProductReadDTO?>> CreateProductAsync(ProductCreateUpdateDTO productDTO)
    {
        try
        {
            var createdProduct = await _productService.CreateProductAsync(productDTO);

            if (createdProduct is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Product not created");
            }

            return CreatedAtAction(nameof(GetProductByIdAsync), new { productId = createdProduct.Id }, createdProduct);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("{productId:int}")]
    public async Task<ActionResult<ProductReadDTO?>> UpdateProductAsync(int productId, ProductCreateUpdateDTO productDTO)
    {
        try
        {
            var updatedProduct = await _productService.UpdateProductAsync(productId, productDTO);

            if (updatedProduct is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Product not updated");
            }

            return Ok(updatedProduct);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{productId:int}")]
    public async Task<ActionResult<bool>> DeleteProductAsync(int productId)
    {
        try
        {
            var isDeleted = await _productService.DeleteProductAsync(productId);

            if (!isDeleted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Product not deleted");
            }

            return Ok(isDeleted);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}