using Apollo.DTO;
using Apollo.Models;
using RecrutementNet.DAL;

namespace Apollo.Services;
public class ContractService : IContractService
{
    private readonly IContractDal _contractDAL;

    public ContractService(IContractDal contractDAL)
    {
        _contractDAL = contractDAL;
    }

    public IEnumerable<ContractDTO> GetContracts(int userId)
    {
        return _contractDAL.GetContracts(userId);
    }

    public IEnumerable<Contract> GetContractsByClientId(int id)
    {
        return _contractDAL.GetContractsByClientId(id);
    }

    public IEnumerable<Contract> GetContractsBeforeDate(DateOnly date)
    {
        return _contractDAL.GetContractsBeforeDate(date);
    }

    public Task DeleteAsync(string userId)
    {
        return Task.CompletedTask;
    }
}