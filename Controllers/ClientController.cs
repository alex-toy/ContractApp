using Microsoft.AspNetCore.Mvc;
using RecrutementNet.DTO;
using RecrutementNet.Services.Clients;

namespace RecrutementNet.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{

    private readonly ILogger<ClientController> _logger;
    private readonly IClientService _contractService;

    public ClientController(ILogger<ClientController> logger, IClientService service)
    {
        _logger = logger;
        _contractService = service;
    }

    [HttpGet("GetAllClients")]
    public IEnumerable<ClientDTO> GetAllClients()
    {
        return _contractService.GetAllClients();
    }
}
