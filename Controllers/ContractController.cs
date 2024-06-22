using Apollo.DTO;
using Apollo.Models;
using Apollo.Services;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("GetContracts")]
    public IEnumerable<ContractDTO> GetContracts([FromQuery] int userId)
    {
        return _contractService.GetContracts(userId);
    }

    [HttpGet("GetContractsBeforeDate")]
    public IEnumerable<Contract> GetContractsBeforeDate([FromQuery] DateOnly date) {
        return _contractService.GetContractsBeforeDate(date);
    }

    [HttpGet("GetContractsByClientId")]
    public IEnumerable<Contract> GetContractsByClientId([FromQuery] int id) {
        return this._contractService.GetContractsByClientId(id);
    }

    [HttpDelete()]
    public async void DeleteAsync([FromQuery] string contractId)
    {
        await _contractService.DeleteAsync(contractId);
    }
}
