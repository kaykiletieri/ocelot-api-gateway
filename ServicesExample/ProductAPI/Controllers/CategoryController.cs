using Microsoft.AspNetCore.Mvc;
using ProductAPI.Application.DTOs;
using ProductAPI.Application.Services.Interfaces;

namespace ProductAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{

    private readonly ICategoryService _categoryService = categoryService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryReadDTO>?>> GetCategoriesAsync()
    {
        try
        {
            var categories = await _categoryService.GetAllAsync();

            if (categories is null)
            {
                return NotFound();
            }

            return Ok(categories);
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
