namespace ProductAPI.Application.DTOs;

public class CategoryCreateUpdateDTO
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}
