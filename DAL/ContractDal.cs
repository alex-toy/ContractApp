using Apollo.Data;
using Apollo.DTO;
using Apollo.Models;

namespace RecrutementNet.DAL;

public class ContractDal : IContractDal
{
    //private readonly ICollection<Client> clientsDbSet;
    //private readonly ICollection<Contract> contractsDbSet;

    //public ContractDal(ICollection<Client> clientsDbSet, ICollection<Contract> contractsDbSet)
    //{
    //    this.clientsDbSet = clientsDbSet;
    //    this.contractsDbSet = contractsDbSet;
    //}

    public ContractDal()
    {
        
    }

    public IEnumerable<ContractDTO> GetContracts(int userId)
    {
        IEnumerable<Contract> contracts = ContractsDbSet.Data.Where(c => c.UserId == userId);
        IEnumerable<int> clientIds = contracts.Select(c => c.ClientId);
        IEnumerable<Client> clients = ClientsDbSet.Data.Where(c => clientIds.Contains(c.Id));

        return contracts.Select(c => c.ToContractDto(clients));
    }

    public IEnumerable<Contract> GetContractsByClientId(int id)
    {
        return ContractsDbSet.Data.Where(c => c.ClientId == id);
    }

    public IEnumerable<Contract> GetContractsBeforeDate(DateOnly date)
    {
        return ContractsDbSet.Data.Where(c => c.Date >= date);
    }

    public Task DeleteAsync(string userId)
    {
        //contractsDbSet = contractsDbSet.Where(c =>  !c.UserId.Equals(userId));
        return Task.CompletedTask;
    }
}
