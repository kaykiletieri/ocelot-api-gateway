namespace ProductAPI.Domain;

public class Category : BaseEntity
{
    public virtual required string Name { get; set; }
    public virtual string? Description { get; set; }
}