using Apollo.Models;
using Moq;
using RecrutementNet.DAL.Clients;
using RecrutementNet.DAL.Contracts;
using RecrutementNet.DTO.Contracts;
using RecrutementNet.Services.Contracts;

namespace ContractApp.Tests;

public class ContractServiceTest : IClassFixture<ContractDal>, IClassFixture<ClientDal>
{
    private readonly ContractDal _contractDAL;
    private readonly ClientDal _clientDAL;
    private readonly ContractService _contractService;

    public ContractServiceTest(ContractDal contractDal, ClientDal clientDAL)
    {
        _contractDAL = contractDal;
        _clientDAL = clientDAL;
        _contractService = new ContractService(_contractDAL, _clientDAL);
    }

    [Fact]
    public void GetAllContracts_works_well()
    {
        IEnumerable<ContractDTO> contracts = _contractService.GetAllContracts();

        Assert.True(contracts.Count() > 0, "There are somme contracts in the database");
    }

    [Theory]
    [InlineData(1)]
    public void GetContractsByClientId_works_well(int clientId)
    {
        Mock<ContractDal> contractDalMock = new ();
        Mock<ClientDal> clientDalMock = new ();
        ContractService contractService = new (contractDalMock.Object, clientDalMock.Object);

        List<Contract> contractsFromDb = new() {
            new(1, new DateOnly(2001, 10, 10), 1, 1),
            new(2, new DateOnly(2001, 10, 12), 2, 1),
        };

        List<Client> clientsFromDb = new() {
            new(1, "Client 1", "Address 1"),
            new(2, "Client 2", "Address 2"),
            new(3, "Client 3", "Address 3")
        };

        contractDalMock.Setup(x =>  x.GetAll(It.IsAny<Func<Contract, bool>?>())).Returns(contractsFromDb);
        clientDalMock.Setup(x =>  x.GetAll(It.IsAny<Func<Client, bool>?>())).Returns(clientsFromDb);

        IEnumerable<ContractDTO> contractsDtos = contractService.GetContractsByClientId(clientId);
        List<int> contractIds = contractsDtos.Select(c => c.Id).ToList();

        Assert.True(contractIds.Contains(1), $"contract 1 should be in the list of contracts for client {clientId}");
        Assert.True(contractIds.Contains(2), $"contract 2 should be in the list of contracts for client {clientId}");
        Assert.True(!contractIds.Contains(3), $"contract 3 should not be in the list of contracts for client {clientId}");
    }
}
