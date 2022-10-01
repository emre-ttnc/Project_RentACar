using Application.DTOs.BrandDTOs;

namespace Application.Models;

public class BrandListModel
{
    public ICollection<BrandListDTO> Items { get; set; } = new List<BrandListDTO>();
}