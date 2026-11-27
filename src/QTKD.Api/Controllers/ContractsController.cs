using Microsoft.AspNetCore.Mvc;
using QTKD.Api.DTOs;
using QTKD.Api.Services;

namespace QTKD.Api.Controllers;

[ApiController]
[Route("api/contracts")]
public sealed class ContractsController(QtkdReadService service) : ControllerBase
{
    [HttpGet("{id:int}")]
    [ProducesResponseType<ContractResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ContractResponse>> GetById(int id, CancellationToken cancellationToken)
    {
        var contract = await service.GetContractAsync(id, cancellationToken);
        if (contract is null)
        {
            return Problem(statusCode: StatusCodes.Status404NotFound,
                detail: $"No contract exists with ID {id}.");
        }

        return Ok(contract);
    }
}
