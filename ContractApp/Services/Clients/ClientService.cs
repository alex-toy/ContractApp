using Apollo.Models;
using RecrutementNet.DAL.Generics;
using RecrutementNet.DTO.Clients;

namespace RecrutementNet.Services.Clients;

public class ClientService : IClientService
{
    private readonly IGenericDal<Client> _clientDAL;

    public ClientService(IGenericDal<Client> clientDAL)
    {
        _clientDAL = clientDAL;
    }

    public IEnumerable<ClientDTO> GetAllClients()
    {
        IEnumerable<Client> clients = _clientDAL.GetAll();

        return clients.Select(client => client.ToDto());
    }

    public Task<int> CreateClient(ClientUpsertDto client)
    {
        return _clientDAL.Create(client.ToModel());
    }
}
