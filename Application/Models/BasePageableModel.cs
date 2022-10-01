namespace Application.Models;

public class BasePageableModel
{
    public int Index { get; set; }
    public int PageSize { get; set; }
    public int Count { get; set; }
    public int PageCount { get; set; }
    public bool HasPrevious { get; set; }
    public bool HasNext { get; set; }
}