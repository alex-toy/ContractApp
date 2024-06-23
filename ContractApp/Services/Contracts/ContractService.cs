using Apollo.Models;
using RecrutementNet.DAL.Generics;
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
        IEnumerable<Contract> contracts = _contractDAL.GetAll();
        IEnumerable<int> contractClientIds = contracts.Select(contract => contract.ClientId);
        IEnumerable<Client> clients = _clientDAL.GetAll(client => contractClientIds.Contains(client.Id));

        return contracts.Select(contract => contract.ToDto(GetClientName(contract, clients)));
    }

    public IEnumerable<ContractDTO> GetContractsByUserId(int userId)
    {
        IEnumerable<Contract> contracts = _contractDAL.GetAll(contract => contract.UserId == userId);
        IEnumerable<int> contractClientIds = contracts.Select(contract => contract.ClientId);
        IEnumerable<Client> clients = _clientDAL.GetAll(client => contractClientIds.Contains(client.Id));

        return contracts.Select(contract => contract.ToDto(GetClientName(contract, clients)));
    }

    public IEnumerable<Contract> GetContractsByClientId(int id)
    {
        return _contractDAL.GetAll(contract => contract.ClientId == id);
    }

    public IEnumerable<Contract> GetContractsBeforeDate(DateOnly date)
    {
        return _contractDAL.GetAll(contract => contract.Date >= date);
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