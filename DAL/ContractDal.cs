using Apollo.Data;
using Apollo.DTO;
using Apollo.Models;

namespace RecrutementNet.DAL;

public class ContractDal : IContractDal
{
    private readonly ICollection<Contract> _contractDbSet;
    private readonly ICollection<Client> _clientDbSet;

    public ContractDal()
    {
        _contractDbSet = ContractsDbSet.Data;
        _clientDbSet = ClientsDbSet.Data;
    }

    public IEnumerable<ContractDTO> GetContracts(int userId)
    {
        IEnumerable<Contract> contracts = _contractDbSet.Where(c => c.UserId == userId);
        IEnumerable<int> clientIds = contracts.Select(c => c.ClientId);
        IEnumerable<Client> clients = _clientDbSet.Where(c => clientIds.Contains(c.Id));

        return contracts.Select(c => c.ToContractDto(clients));
    }

    public IEnumerable<Contract> GetContractsByClientId(int id)
    {
        return _contractDbSet.Where(c => c.ClientId == id);
    }

    public IEnumerable<Contract> GetContractsBeforeDate(DateOnly date)
    {
        return _contractDbSet.Where(c => c.Date >= date);
    }

    public Task DeleteAsync(string userId)
    {
        //contractsDbSet = contractsDbSet.Where(c =>  !c.UserId.Equals(userId));
        return Task.CompletedTask;
    }
}