using Apollo.DTO;
using Apollo.Models;
using RecrutementNet.DTO;

namespace RecrutementNet.Services.Contracts
{
    public interface IContractService
    {
        IEnumerable<ContractDTO> GetAllContracts();
        IEnumerable<ContractDTO> GetContractsByUserId(int userId);
        IEnumerable<Contract> GetContractsBeforeDate(DateOnly date);
        IEnumerable<Contract> GetContractsByClientId(int id);
        Task CreateContract(ContractUpsertDTO contract);
        Task UpdateContract(ContractUpsertDTO contract);
        Task DeleteByContractId(int contractId);
    }
}