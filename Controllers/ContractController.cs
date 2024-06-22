using Apollo.DTO;
using Apollo.Models;
using Microsoft.AspNetCore.Mvc;
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
    public IEnumerable<Contract> GetContractsBeforeDate([FromQuery] DateOnly date) {
        return _contractService.GetContractsBeforeDate(date);
    }

    [HttpGet("GetContractsByClientId")]
    public IEnumerable<Contract> GetContractsByClientId([FromQuery] int id)
    {
        return _contractService.GetContractsByClientId(id);
    }

    [HttpPost("CreateContract")]
    public Task CreateContract([FromBody] Contract contract)
    {
        return _contractService.CreateContract(contract);
    }

    [HttpPost("UpdateContract")]
    public Task UpdateContract([FromBody] Contract contract)
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
