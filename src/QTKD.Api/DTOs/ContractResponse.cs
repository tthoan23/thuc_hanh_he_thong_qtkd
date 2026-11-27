namespace QTKD.Api.DTOs;

public sealed record ContractResponse(
    int Id,
    string ContractNo,
    int CustomerId,
    DateOnly? StartDate,
    DateOnly? EndDate,
    string Status);
