using Microsoft.EntityFrameworkCore;
using QTKD.Api.Data;
using QTKD.Api.Entities;

namespace QTKD.Api.Repositories;

public sealed class QtkdReadRepository(QtkdDbContext dbContext)
{
    public Task<List<Customer>> GetCustomersAsync(CancellationToken cancellationToken) =>
        dbContext.Customers.AsNoTracking()
            .OrderBy(customer => customer.Id)
            .ToListAsync(cancellationToken);

    public Task<Contract?> GetContractAsync(int id, CancellationToken cancellationToken) =>
        dbContext.Contracts.AsNoTracking()
            .SingleOrDefaultAsync(contract => contract.Id == id, cancellationToken);
}
