using Apollo.Data;
using Apollo.DTO;
using Apollo.Models;

namespace Apollo.Services;
public class ContractService
{
    private readonly ICollection<Client> clientsDbSet;
    private readonly ICollection<Contract> contractsDbSet;

    public ContractService(
        ICollection<Client> clientsDbSet, 
        ICollection<Contract> contractsDbSet)
    {
        this.clientsDbSet = clientsDbSet;
        this.contractsDbSet = contractsDbSet;
    }

    public IEnumerable<ContractDTO> GetContracts(int userId)
    {
        var contracts = contractsDbSet.Where(c => c.UserId == userId).ToList();
        var clients = clientsDbSet.ToList();

        var dtoList = new List<ContractDTO>();
        foreach(var contract in contracts) {
            dtoList.Add(new ContractDTO(contract.Id, contract.Date, clients.First(cl => cl.Id == contract.Id).Name));
        }
        return dtoList;
    }

    public IEnumerable<Contract> GetContractsByClientId(int id) {
        return contractsDbSet.Where(c => c.ClientId == id);
    }

    public IEnumerable<Contract> GetContractsBeforeDate(DateOnly date)
    {
        return contractsDbSet.Where(c => c.Date >= date);
    }
    public Task DeleteAsync(string userId)
    {
        return Task.CompletedTask;
    }
}