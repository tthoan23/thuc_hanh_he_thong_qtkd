namespace QTKD.Api.Entities;

public sealed class PriceItem
{
    public int PriceListId { get; set; }
    public required string ServiceCode { get; set; }
    public decimal UnitPrice { get; set; }
}
