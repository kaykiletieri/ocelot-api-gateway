namespace UserAPI.Domain;

public class BaseEntity
{
    public virtual required Guid Id { get; set; }
    public virtual required DateTime CreatedAt { get; set; }
    public virtual DateTime UpdatedAt { get; set; }
    public virtual DateTime DeletedAt { get; set; }
}
