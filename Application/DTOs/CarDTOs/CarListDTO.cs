using Domain.Enums;

namespace Application.DTOs.CarDTOs;

public class CarListDTO
{
    public string Id { get; set; } = string.Empty;
    public int ModelYear { get; set; }
    public float DailyPrice { get; set; }
    public string ImageURL { get; set; } = string.Empty;
    public CarState CarState { get; set; } = 0;
}