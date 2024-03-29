﻿using Microsoft.AspNetCore.Mvc;
using ProductAPI.Application.DTOs;
using ProductAPI.Application.Services.Interfaces;

namespace ProductAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

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

    [HttpGet("{categoryId:int}")]
    public async Task<ActionResult<CategoryReadDTO?>> GetCategoryByIdAsync(int categoryId)
    {
        try
        {
            var category = await _categoryService.GetByIdAsync(categoryId);

            if (category is null)
            {
                return NotFound();
            }

            return Ok(category);
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
    public async Task<ActionResult<CategoryReadDTO?>> CreateCategoryAsync(CategoryCreateUpdateDTO categoryCreateDTO)
    {
        try
        {
            var category = await _categoryService.CreateAsync(categoryCreateDTO);

            if (category is null)
            {
                return NotFound();
            }

            return Ok(category);
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

    [HttpPut]
    public async Task<ActionResult<CategoryReadDTO?>> UpdateCategoryAsync(int categoryId, CategoryCreateUpdateDTO categoryUpdateDTO)
    {
        try
        {
            var category = await _categoryService.UpdateAsync(categoryId, categoryUpdateDTO);

            if (category is null)
            {
                return NotFound();
            }

            return Ok(category);
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

    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteCategoryAsync(int categoryId)
    {
        try
        {
            var isDeleted = await _categoryService.DeleteAsync(categoryId);

            if (!isDeleted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Category not deleted");
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