namespace QTKD.Api.Entities;

public sealed class Contract
{
    public int Id { get; set; }
    public required string ContractNo { get; set; }
    public int CustomerId { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public ContractStatus Status { get; set; }
}

public enum ContractStatus
{
    Draft
}
