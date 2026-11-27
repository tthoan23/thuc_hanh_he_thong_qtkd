using QTKD.Api.DTOs;
using QTKD.Api.Repositories;

namespace QTKD.Api.Services;

public sealed class QtkdReadService(QtkdReadRepository repository)
{
    public async Task<IReadOnlyList<CustomerResponse>> GetCustomersAsync(CancellationToken cancellationToken)
    {
        var customers = await repository.GetCustomersAsync(cancellationToken);
        return customers.Select(customer => new CustomerResponse(
            customer.Id,
            customer.Name,
            customer.Status.ToString())).ToArray();
    }

    public async Task<ContractResponse?> GetContractAsync(int id, CancellationToken cancellationToken)
    {
        var contract = await repository.GetContractAsync(id, cancellationToken);
        if (contract is null)
        {
            return null;
        }

        return new ContractResponse(
            contract.Id,
            contract.ContractNo,
            contract.CustomerId,
            contract.StartDate,
            contract.EndDate,
            contract.Status.ToString());
    }
}
