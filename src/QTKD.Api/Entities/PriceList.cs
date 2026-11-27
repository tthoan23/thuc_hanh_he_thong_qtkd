namespace QTKD.Api.Entities;

public sealed class PriceList
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateOnly EffectiveDate { get; set; }
}
