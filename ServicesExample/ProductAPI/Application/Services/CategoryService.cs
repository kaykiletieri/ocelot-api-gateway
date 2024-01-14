using AutoMapper;
using ProductAPI.Application.DTOs;
using ProductAPI.Application.Services.Interfaces;
using ProductAPI.Domain;
using ProductAPI.Infrastructure.Repositories.Interfaces;

namespace ProductAPI.Application.Services;

public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
{
    //Preciso melhorar
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<CategoryReadDTO>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllActiveAsync();
        return _mapper.Map<IEnumerable<CategoryReadDTO>>(categories);
    }

    public async Task<CategoryReadDTO> GetByIdAsync(int id)
    {
        var category = await _categoryRepository.GetActiveByIdAsync(id);
        return _mapper.Map<CategoryReadDTO>(category);
    }

    public async Task<CategoryReadDTO> CreateAsync(CategoryCreateUpdateDTO categoryCreateDTO)
    {
        var category = _mapper.Map<Category>(categoryCreateDTO);
        var createdCategory = await _categoryRepository.CreateAsync(category);
        return _mapper.Map<CategoryReadDTO>(createdCategory);
    }

    public async Task<CategoryReadDTO> UpdateAsync(int id, CategoryCreateUpdateDTO categoryUpdateDTO)
    {
        var category = _mapper.Map<Category>(categoryUpdateDTO);
        var updatedCategory = await _categoryRepository.UpdateAsync(category);
        return _mapper.Map<CategoryReadDTO>(updatedCategory);
    }

    public async Task DeleteAsync(int id)
    {
        await _categoryRepository.DeleteAsync(id);
    }
}
