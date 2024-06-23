using Apollo.Models;
using ContractApp.Shared.Generics;
using RecrutementNet.DTO.Contracts;

namespace RecrutementNet.Services.Contracts;

public class ContractService : IContractService
{
    private readonly IGenericDal<Contract> _contractDAL;
    private readonly IGenericDal<Client> _clientDAL;

    public ContractService(IGenericDal<Contract> contractDAL, IGenericDal<Client> clientDAL)
    {
        _contractDAL = contractDAL;
        _clientDAL = clientDAL;
    }

    public IEnumerable<ContractDTO> GetAllContracts()
    {
        return GetContracts();
    }

    public IEnumerable<ContractDTO> GetContractsByUserId(int userId)
    {
        return GetContracts(contract => contract.UserId == userId);
    }

    public IEnumerable<ContractDTO> GetContractsByClientId(int id)
    {
        return GetContracts(contract => contract.ClientId == id);
    }

    public IEnumerable<ContractDTO> GetContractsBeforeDate(DateOnly date)
    {
        return GetContracts(contract => contract.Date >= date);
    }

    private IEnumerable<ContractDTO> GetContracts(Func<Contract, bool>? predicate = null)
    {
        IEnumerable<Contract> contracts = _contractDAL.GetAll(predicate);
        IEnumerable<int> contractClientIds = contracts.Select(contract => contract.ClientId);
        IEnumerable<Client> clients = _clientDAL.GetAll(client => contractClientIds.Contains(client.Id));

        return contracts.Select(contract => contract.ToDto(GetClientName(contract, clients)));
    }

    public Task<int> CreateContract(ContractUpsertDTO contract)
    {
        return _contractDAL.Create(contract.ToModel());
    }

    public Task UpdateContract(ContractUpsertDTO contract)
    {
        return _contractDAL.Update(contract.ToModel());
    }

    public Task DeleteByContractId(int contractId)
    {
        return _contractDAL.Delete(contract => contract.Id.Equals(contractId));
    }

    private static string? GetClientName(Contract contract, IEnumerable<Client> clients)
    {
        return clients.FirstOrDefault(client => client.Id == contract.ClientId)?.Name;
    }
}