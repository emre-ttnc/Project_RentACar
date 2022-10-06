namespace Domain.Entities.CarEntities;

public class Model : BaseEntity
{
    public Guid BrandId { get; set; } = Guid.NewGuid();
    public Brand Brand { get; set; } = new();
    public string ModelName { get; set; } = string.Empty;
    public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();

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