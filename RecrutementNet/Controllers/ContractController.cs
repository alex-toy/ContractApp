using Apollo.Data;
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
    private readonly ContractService service;

    public ContractController(ILogger<ContractController> logger)
    {
        _logger = logger;
        service = new ContractService(ClientsDbSet.Data, ContractsDbSet.Data);
    }

    [HttpGet()]
    public IEnumerable<ContractDTO> Get([FromQuery] int userId)
    {
        return service.GetContracts(userId);
    }

    [HttpGet()]
    public IEnumerable<Contract> GetContractsByDate([FromQuery] DateOnly date) {
        return service.GetContractsBeforeDate(date);
    }

    public IEnumerable<Contract> GetContractsById([FromQuery] int id) {
        return this.service.GetContractsByClientId(id);
    }

    [HttpPost()]
    public async void DeleteAsync([FromQuery] string contractId)
    {
        await service.DeleteAsync(contractId);
    }
}
