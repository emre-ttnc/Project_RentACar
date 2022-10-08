using Application.DTOs.BrandDTOs;

namespace Application.Models;

public class BrandListPageableModel : BasePageableModel
{
    public ICollection<BrandListDTO> Items { get; set; } = new List<BrandListDTO>();
}