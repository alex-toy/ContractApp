using RecrutementNet.DTO.Clients;

namespace RecrutementNet.Services.Clients
{
    public interface IClientService
    {
        IEnumerable<ClientDTO> GetAllClients();
        Task<int> CreateClient(ClientUpsertDto client);
    }
}