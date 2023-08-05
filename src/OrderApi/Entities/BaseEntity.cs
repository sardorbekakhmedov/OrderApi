namespace OrderApi.Entities;

public abstract class BaseEntity<T> where T: struct
{
    public T Id { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime? UpdateAt { get; set; }
}

public abstract class BaseEntity : BaseEntity<Guid>
{ }