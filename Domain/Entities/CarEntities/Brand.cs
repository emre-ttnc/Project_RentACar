namespace Domain.Entities.CarEntities;

public class Brand : BaseEntity
{
    public string BrandName { get; set; } = string.Empty;
    public virtual ICollection<Model> Models { get; set; } = new HashSet<Model>();

    public Brand()
    {
    }
    public Brand(Guid id, string brandName, ICollection<Model> models)
    {
        Id = id;
        BrandName = brandName;
        Models = models;
    }
}
