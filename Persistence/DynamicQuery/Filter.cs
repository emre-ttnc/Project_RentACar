namespace Persistence.DynamicQuery;

public class Filter
{
    public string Field { get; set; }
    public string Operator { get; set; }

    public string? Value { get; set; }
    public string? Logic { get; set; }
    public IEnumerable<Filter>? Filters { get; set; }

    public Filter()
    {
    }

    public Filter(string filed, string @operator, string? value, string? logic, IEnumerable<Filter>? filters)
    {
        Field = filed;
        Operator = @operator;
        Value = value;
        Logic = logic;
        Filters = filters;
    }
}