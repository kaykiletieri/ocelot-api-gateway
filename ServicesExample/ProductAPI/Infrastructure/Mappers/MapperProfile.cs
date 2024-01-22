using AutoMapper;
using ProductAPI.Application.DTOs;
using ProductAPI.Domain;

namespace ProductAPI.Infrastructure.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<ProductCreateUpdateDTO, Product>();
        CreateMap<Product, ProductReadDTO>();

        CreateMap<CategoryCreateUpdateDTO, Category>();
        CreateMap<Category, CategoryReadDTO>();
    }
}