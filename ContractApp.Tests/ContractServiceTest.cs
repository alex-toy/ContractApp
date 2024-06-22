using Apollo.DTO;
using RecrutementNet.Services.Contracts;

namespace ContractApp.Tests;

public class ContractServiceTest : IClassFixture<ContractService>
{
    private readonly ContractService _contractService;

    public ContractServiceTest(ContractService contractService)
    {
        _contractService = contractService;
    }

    [Fact]
    public void Test_dummy()
    {
        IEnumerable<ContractDTO> temp = _contractService.GetAllContracts();

        Assert.True(1 == 1, "xxxxxxxxxxxxxxxxxx");
    }
}
