using RecrutementNet.DTO;

namespace RecrutementNet.Services.Clients
{
    public interface IClientService
    {
        IEnumerable<ClientDTO> GetAllClients();
    }
}