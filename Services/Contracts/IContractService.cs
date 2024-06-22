using Apollo.DTO;
using Apollo.Models;

namespace RecrutementNet.Services.Contracts
{
    public interface IContractService
    {
        IEnumerable<ContractDTO> GetContractsByUserId(int userId);
        IEnumerable<Contract> GetContractsBeforeDate(DateOnly date);
        IEnumerable<Contract> GetContractsByClientId(int id);
        Task DeleteByContractId(int contractId);
        Task CreateContract(Contract contract);
        Task UpdateContract(Contract contract);
        IEnumerable<ContractDTO> GetAllContracts();
    }
}