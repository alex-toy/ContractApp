using Apollo.Models;
using RecrutementNet.DTO.Contracts;

namespace RecrutementNet.Services.Contracts
{
    public interface IContractService
    {
        IEnumerable<ContractDTO> GetAllContracts();
        IEnumerable<ContractDTO> GetContractsByUserId(int userId);
        IEnumerable<Contract> GetContractsBeforeDate(DateOnly date);
        IEnumerable<Contract> GetContractsByClientId(int id);
        Task<int> CreateContract(ContractUpsertDTO contract);
        Task UpdateContract(ContractUpsertDTO contract);
        Task DeleteByContractId(int contractId);
    }
}