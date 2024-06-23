using Apollo.Models;
using Microsoft.AspNetCore.Mvc;
using RecrutementNet.DTO.Contracts;
using RecrutementNet.Services.Contracts;

namespace RecrutementNet.Controllers;

[ApiController]
[Route("[controller]")]
public class ContractController : ControllerBase
{

    private readonly ILogger<ContractController> _logger;
    private readonly IContractService _contractService;

    public ContractController(ILogger<ContractController> logger, IContractService service)
    {
        _logger = logger;
        _contractService = service;
    }

    [HttpGet("GetAllContracts")]
    public IEnumerable<ContractDTO> GetAllContracts()
    {
        return _contractService.GetAllContracts();
    }

    [HttpGet("GetContractsByUserId")]
    public IEnumerable<ContractDTO> GetContractsByUserId([FromQuery] int userId)
    {
        return _contractService.GetContractsByUserId(userId);
    }

    [HttpGet("GetContractsBeforeDate")]
    public IEnumerable<ContractDTO> GetContractsBeforeDate([FromQuery] DateOnly date) {
        return _contractService.GetContractsBeforeDate(date);
    }

    [HttpGet("GetContractsByClientId")]
    public IEnumerable<ContractDTO> GetContractsByClientId([FromQuery] int id)
    {
        return _contractService.GetContractsByClientId(id);
    }

    [HttpPost("CreateContract")]
    public async Task<ActionResult<int>> CreateContractAsync([FromBody] ContractUpsertDTO contract)
    {
        return await _contractService.CreateContract(contract);
    }

    [HttpPost("UpdateContract")]
    public Task UpdateContract([FromBody] ContractUpsertDTO contract)
    {
        return _contractService.UpdateContract(contract);
    }

    [HttpDelete("DeleteByContractIdAsync")]
    public async Task DeleteByContractIdAsync([FromQuery] int contractId)
    {
        try
        {
            await _contractService.DeleteByContractId(contractId);
        }
        catch (Exception ex)
        {
            _logger.LogDebug(ex.Message);
        }
    }
}
