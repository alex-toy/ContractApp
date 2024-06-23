using Microsoft.AspNetCore.Mvc;
using RecrutementNet.DTO.Clients;
using RecrutementNet.DTO.Contracts;
using RecrutementNet.Services.Clients;

namespace RecrutementNet.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{

    private readonly ILogger<ClientController> _logger;
    private readonly IClientService _clientService;

    public ClientController(ILogger<ClientController> logger, IClientService service)
    {
        _logger = logger;
        _clientService = service;
    }

    [HttpGet("GetAllClients")]
    public IEnumerable<ClientDTO> GetAllClients()
    {
        return _clientService.GetAllClients();
    }

    [HttpPost("CreateClient")]
    public async Task<ActionResult<int>> CreateClientAsync([FromBody] ClientUpsertDto client)
    {
        try
        {
            return await _clientService.CreateClient(client);
        }
        catch (Exception ex)
        {
            _logger.LogDebug(ex.Message);
            return BadRequest(ex.Message);
        }
    }
}
