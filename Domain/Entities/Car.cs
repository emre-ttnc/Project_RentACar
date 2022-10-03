using Domain.Enums;

namespace Domain.Entities;

public class Car : BaseEntity
{
    public Guid ModelId { get; set; }
    public Model Model { get; set; }
    public int ModelYear { get; set; }
    public float DailyPrice { get; set; }
    public string ImageURL { get; set; } = string.Empty;
    public CarState CarState { get; set; }

    public Car() { }

    public Car(Guid id, Guid modelId, int modelYear, float dailyPrice, string imageURL, CarState carState)
    {
        Id = id;
        ModelId = modelId;
        ModelYear = modelYear;
        DailyPrice = dailyPrice;
        ImageURL = imageURL;
        CarState = carState;
    }
}