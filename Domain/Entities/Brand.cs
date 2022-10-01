namespace Domain.Entities;

public class Brand : BaseEntity
{
    public string BrandName { get; set; }

    public Brand(string brandName)
    {
        BrandName = brandName;
    }
    public Brand(Guid id, string brandName) : this(brandName)
    {
        Id = id;
    }
}
