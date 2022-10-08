using Application.DTOs.CarDTOs;

namespace Application.DTOs.ModelDTOs;

public class ModelListDTO
{
    public string Id { get; set; } = string.Empty;
    public string ModelName { get; set; } = string.Empty;
    public string BrandName { get; set; } = string.Empty;
    public ICollection<CarListDTO> Cars { get; set; } = new HashSet<CarListDTO>();
}