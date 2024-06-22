using Apollo.Models;
using RecrutementNet.DAL.Clients;

namespace ContractApp.Tests;

public class ClientDalTest : IClassFixture<ClientDal>
{
    private readonly ClientDal _clientDAL;

    public ClientDalTest(ClientDal contractService)
    {
        _clientDAL = contractService;
    }

    [Fact]
    public void Create_insert_item_in_database()
    {
        Client client = new Client(0, "my_client", "paris");

        _clientDAL.Create(client);
        Client? clientDb = _clientDAL.Get(c => c.Name.Equals("my_client"));

        Assert.True(clientDb is not null, "clientDb should not be null");
    }

    [Theory]
    [InlineData(1, "update_client_1", "update_address_1")]
    [InlineData(2, "update_client_2", "update_address_3")]
    public void Update_works_well(int clientId, string clientName, string clientAddress)
    {
        Client client = new Client(clientId, clientName, clientAddress);

        _clientDAL.Update(client);

        Client? clientDb = _clientDAL.Get(c => c.Id == clientId && c.Name.Equals(clientName) && c.Address.Equals(clientAddress));

        Assert.True(clientDb is not null, "clientDb should not be null");
    }

    [Fact]
    public void All_ids_in_the_database_are_different()
    {
        IEnumerable<Client> clients = _clientDAL.GetAll();
        int clientIdsCount = clients.Select(c => c.Id).Count();
        int clientIdsDistinctCount = clients.Select(c => c.Id).Distinct().Count();
        Assert.True(clientIdsCount == clientIdsDistinctCount, "All ids in the database are different");
    }
}