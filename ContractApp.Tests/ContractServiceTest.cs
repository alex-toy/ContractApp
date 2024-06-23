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
}
