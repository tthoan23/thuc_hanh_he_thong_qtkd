namespace QTKD.Api.Entities;

public sealed class Customer
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public CustomerStatus Status { get; set; }
}

public enum CustomerStatus
{
    Active,
    Inactive
}
