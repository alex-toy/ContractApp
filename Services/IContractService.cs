using Apollo.DTO;
using Apollo.Models;

namespace Apollo.Services
{
    public interface IContractService
    {
        Task DeleteAsync(string userId);
        IEnumerable<ContractDTO> GetContracts(int userId);
        IEnumerable<Contract> GetContractsBeforeDate(DateOnly date);
        IEnumerable<Contract> GetContractsByClientId(int id);
    }
}