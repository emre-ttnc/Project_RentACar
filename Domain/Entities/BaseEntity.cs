namespace Domain.Entities;

public class BaseEntity
{
    public Guid Id { get; set; }

    public BaseEntity() { }
    public BaseEntity(Guid id) : this()
    {
        Id = id;
    }

}
