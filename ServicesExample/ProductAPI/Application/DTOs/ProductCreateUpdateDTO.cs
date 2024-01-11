namespace ProductAPI.Application.DTOs;

public class ProductCreateUpdateDTO
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required decimal Price { get; set; }
    public required int StockQuantity { get; set; }
}
