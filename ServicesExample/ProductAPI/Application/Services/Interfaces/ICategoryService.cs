﻿using ProductAPI.Application.DTOs;

namespace ProductAPI.Application.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryReadDTO>?> GetAllAsync();
    Task<CategoryReadDTO?> GetByIdAsync(int id);
    Task<CategoryReadDTO?> CreateAsync(CategoryCreateUpdateDTO categoryCreateDTO);
    Task<CategoryReadDTO?> UpdateAsync(int id, CategoryCreateUpdateDTO categoryUpdateDTO);
    Task<bool> DeleteAsync(int id);
}