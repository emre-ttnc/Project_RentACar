using Application.DTOs.ModelDTOs;

namespace Application.Models;

public class ModelListModel
{
    public ICollection<ModelListDTO> Items { get; set; } = new List<ModelListDTO>();
}