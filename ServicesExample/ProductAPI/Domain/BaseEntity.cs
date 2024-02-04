namespace ProductAPI.Domain;

public class BaseEntity
{
    public virtual Guid Id { get; set; }
    public required virtual DateTime CreatedAt { get; set; }
    public virtual DateTime? UpdatedAt { get; set; }
    public virtual DateTime? DeletedAt { get; set; }
}