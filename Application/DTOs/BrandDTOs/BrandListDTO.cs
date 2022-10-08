using Application.DTOs.ModelDTOs;

namespace Application.DTOs.BrandDTOs;

public class BrandListDTO
{
    public string Id { get; set; } = string.Empty;
    public string BrandName { get; set; } = string.Empty;
    public virtual ICollection<ModelListDTO> Models { get; set; } = new HashSet<ModelListDTO>();
}