using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Application.DTOs;
using ProductAPI.Application.Services.Interfaces;

namespace ProductAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

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
}
