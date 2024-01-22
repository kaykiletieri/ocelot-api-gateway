namespace ProductAPI.Domain;

public class BaseEntity
{
    public virtual int Id { get; set; }
    public required virtual DateTime CreatedAt { get; set; }
    public virtual DateTime? UpdatedAt { get; set; }
    public virtual DateTime? DeletedAt { get; set; }
}