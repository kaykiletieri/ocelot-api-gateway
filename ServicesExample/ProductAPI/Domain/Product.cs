namespace ProductAPI.Domain;

public class Product : BaseEntity
{
    public virtual required string Name { get; set; }
    public virtual string? Description { get; set; }
    public virtual required decimal Price { get; set; }
    public virtual required int StockQuantity { get; set; }
}
