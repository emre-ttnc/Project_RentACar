namespace Domain.Entities;

public class Model : BaseEntity
{
    public Guid BrandId { get; set; }
    public Brand Brand { get; set; }
    public string ModelName { get; set; } = string.Empty;
    public virtual ICollection<Car> Cars { get; set; }

    public Model()
    {
    }

    public Model(Guid id, Guid brandId, Brand brand, string modelName, ICollection<Car> cars)
    {
        Id = id;
        BrandId = brandId;
        Brand = brand;
        ModelName = modelName;
        Cars = cars;
    }
}