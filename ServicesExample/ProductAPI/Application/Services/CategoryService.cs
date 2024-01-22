using AutoMapper;
using ProductAPI.Application.DTOs;
using ProductAPI.Application.Services.Interfaces;
using ProductAPI.Domain;
using ProductAPI.Infrastructure.Repositories.Interfaces;

namespace ProductAPI.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryReadDTO>?> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllActiveAsync();

        if (categories is null || !categories.Any())
        {
            return null;
        }

        return _mapper.Map<IEnumerable<CategoryReadDTO>>(categories);
    }

    public async Task<CategoryReadDTO?> GetByIdAsync(int id)
    {
        var category = await _categoryRepository.GetActiveByIdAsync(id);

        if (category is null)
        {
            return null;
        }

        return _mapper.Map<CategoryReadDTO>(category);
    }

    public async Task<CategoryReadDTO?> CreateAsync(CategoryCreateUpdateDTO categoryCreateDTO)
    {
        var category = _mapper.Map<Category>(categoryCreateDTO)
            ;
        var createdCategory = await _categoryRepository.CreateAsync(category);

        return createdCategory is null
            ? throw new Exception($"Category with id {category.Id} not created")
            : _mapper.Map<CategoryReadDTO>(createdCategory);
    }

    public async Task<CategoryReadDTO?> UpdateAsync(int id, CategoryCreateUpdateDTO categoryUpdateDTO)
    {
        var category = await _categoryRepository.GetActiveByIdAsync(id) ?? throw new ArgumentException($"Category with id {id} not found");

        var updatedCategory = await _categoryRepository.UpdateAsync(_mapper.Map(categoryUpdateDTO, category));
        return updatedCategory is null
            ? throw new Exception($"Category with id {category.Id} not updated")
            : _mapper.Map<CategoryReadDTO>(updatedCategory);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _categoryRepository.GetActiveByIdAsync(id) ?? throw new ArgumentException($"Category with id {id} not found");
        await _categoryRepository.SoftDeleteAsync(category);

        return true;
    }
}